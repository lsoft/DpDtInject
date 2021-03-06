using DpdtInject.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DpdtInject.Tests.Wrapper.Func.NonGeneric.Hierarchy2
{
    [TestClass]
    public class WrapperFuncNonGenericHierarchy2_Fixture
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
                nameof(WrapperFuncNonGenericHierarchy2_Cluster.WrapperFuncNonGenericHierarchy2_ClusterTester),
                nameof(TestResources.WrapperFuncNonGenericHierarchy2_Cluster),
                TestResources.WrapperFuncNonGenericHierarchy2_Cluster
                );

            preparation.Check();

            Assert.AreEqual(0, preparation.DiagnosticReporter.ErrorCount, "Error count");
            Assert.AreEqual(0, preparation.DiagnosticReporter.WarningCount, "Warning count");
        }
    }
}
