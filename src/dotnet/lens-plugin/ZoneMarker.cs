using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.Platform.RdFramework;

namespace LensPlugin;

[ZoneMarker]
public class ZoneMarker : IRequire<ILensPluginZone>, IRequire<IRdFrameworkZone>
{
}