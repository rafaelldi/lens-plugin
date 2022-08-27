using System.Net;
using System.Threading.Tasks;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.Platform.RdFramework.Impl;
using JetBrains.ProjectModel;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.Rd.Reflection;
using JetBrains.RdBackend.Common.Features;
using JetBrains.Util;
using LensPlugin.Generated;
using AspNetCoreActivity = OpenTelemetry.Exporter.Rd.Model.AspNetCoreActivity;

namespace LensPlugin;

[SolutionComponent]
internal sealed class LensHost
{
    private readonly ILogger _logger;
    private readonly ShellRdDispatcher _rdDispatcher;
    private readonly Lifetime _lifetime;
    private readonly LensHostModel _lensModel;

    public LensHost(ISolution solution, ILogger logger, ShellRdDispatcher rdDispatcher, Lifetime lifetime)
    {
        _logger = logger;
        _rdDispatcher = rdDispatcher;
        _lifetime = lifetime;
        _lensModel = solution.GetProtocolSolution().GetLensHostModel();
        _lensModel.StartOpenTelemetryHost.Advise(_lifetime, it => StartProtocol(it));
    }

    private void StartProtocol(int port)
    {
        _logger.Info("Start OpenTelemetry RD protocol");
        var scheduler = SingleThreadScheduler.RunOnSeparateThread(_lifetime, "Lens Plugin Scheduler");
        var wire = new SocketWire.Server(
            _lifetime,
            scheduler,
            new IPEndPoint(IPAddress.Loopback, port),
            "Lens Plugin Server"
        );
        var reflectionSerializers = new ReflectionSerializersFacade();
        var serializers = new Serializers(TaskScheduler.Default, reflectionSerializers.Registrar);
        var protocol = new Protocol(
            "Lens Plugin Server",
            serializers,
            new Identities(IdKind.Server),
            scheduler,
            wire,
            _lifetime
        );

        scheduler.Queue(() => RunRdHost(reflectionSerializers, protocol, _lifetime));
    }

    private void RunRdHost(
        ReflectionSerializersFacade reflectionSerializers,
        Protocol protocol,
        Lifetime lifetime)
    {
        var otelModel = reflectionSerializers.InitBind(new OpenTelemetryHostModel(), lifetime, protocol);
        otelModel.OnActivity.Advise(lifetime, it => _rdDispatcher.Queue(() => OnActivity(it)));
    }

    private void OnActivity(AspNetCoreActivity activity)
    {
        var rdActivity = new Generated.AspNetCoreActivity(
            activity.DisplayName,
            activity.Method,
            activity.Target,
            activity.Route,
            activity.StatusCode,
            activity.Duration
        );
        _lensModel.ActivityReceived(rdActivity);
    }
}