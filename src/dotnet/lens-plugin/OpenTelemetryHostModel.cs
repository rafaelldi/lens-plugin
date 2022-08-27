using JetBrains.Collections.Viewable;
using JetBrains.Rd.Reflection;
using OpenTelemetry.Exporter.Rd.Model;

namespace LensPlugin;

[RdExt]
public class OpenTelemetryHostModel : RdExtReflectionBindableBase, IOpenTelemetryHostModel
{
    public ISignal<AspNetCoreActivity> OnActivity { get; }
}