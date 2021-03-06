using DpdtInject.Generator.Core.Producer;
using DpdtInject.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DpdtInject.Injector.Src.Excp;

namespace DpdtInject.Tests.Settings.CrossCluster.OnlyLocalCluster0
{
    [TestClass]
    public class SettingsCrossClusterOnlyLocalCluster0_Fixture
    {
        public TestContext TestContext
        {
            get;
            set;
        }

        [TestMethod]
        public void Test()
        {
            var preparation = new Preparator(
                TestContext,
                nameof(SettingsCrossClusterOnlyLocalCluster0_ClusterTester),
                nameof(TestResources.SettingsCrossClusterOnlyLocalCluster0_Cluster),
                TestResources.SettingsCrossClusterOnlyLocalCluster0_Cluster
                );

            preparation.Check();

            Assert.AreEqual(1, preparation.DiagnosticReporter.ErrorCount, "Error count");
            Assert.AreEqual(0, preparation.DiagnosticReporter.WarningCount, "Warning count");
            Assert.AreEqual(DpdtExceptionTypeEnum.NoBindingAvailable, preparation.DiagnosticReporter.GetDpdtException().Type);
            Assert.AreEqual(typeof(IA).ToGlobalDisplayString(), preparation.DiagnosticReporter.GetDpdtException().AdditionalArgument);
        }
    }
}
