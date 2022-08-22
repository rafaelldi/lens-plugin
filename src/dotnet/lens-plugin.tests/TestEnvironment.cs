using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: Apartment(ApartmentState.STA)]

namespace LensPlugin.Tests
{

    [ZoneDefinition]
    public class LensPluginTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>, IRequire<ILensPluginZone> { }

    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>, IRequire<LensPluginTestEnvironmentZone> { }
    
    [SetUpFixture]
    public class LensPluginTestsAssembly : ExtensionTestEnvironmentAssembly<LensPluginTestEnvironmentZone> { }
}