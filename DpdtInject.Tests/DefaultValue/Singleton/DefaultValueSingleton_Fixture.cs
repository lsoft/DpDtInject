using DpdtInject.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DpdtInject.Tests.DefaultValue.Singleton
{
    [TestClass]
    public class DefaultValueSingleton_Fixture
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
                nameof(DefaultValueSingleton_Cluster.DefaultValueSingleton_ClusterTester),
                nameof(TestResources.DefaultValueSingleton_Cluster),
                TestResources.DefaultValueSingleton_Cluster
                );

            preparation.Check();

            Assert.AreEqual(0, preparation.DiagnosticReporter.ErrorCount, "Error count");
            Assert.AreEqual(0, preparation.DiagnosticReporter.WarningCount, "Warning count");
        }
    }
}
