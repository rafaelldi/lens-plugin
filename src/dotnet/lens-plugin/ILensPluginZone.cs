using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ProjectModel;

namespace LensPlugin;

[ZoneDefinition(ZoneFlags.AutoEnable)]
public interface ILensPluginZone : IProjectModelZone
{
}