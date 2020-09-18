using DpdtInject.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace DpdtInject.Tests.Activation.Excessive.TooManyRoots2
{

    [TestClass]
    public class ActivationExcessiveTooManyRoots2Fixture
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Test()
        {
            var preparation = new Preparator(
                TestContext,
                nameof(ActivationExcessiveTooManyRoots2Module.ActivationExcessiveTooManyRoots2Tester),
                nameof(TestResources.ActivationExcessiveTooManyRoots2Module),
                TestResources.ActivationExcessiveTooManyRoots2Module
                );

            preparation.Check();

            Assert.AreEqual(0, preparation.DiagnosticReporter.ErrorCount, "Error count");
            Assert.AreEqual(0, preparation.DiagnosticReporter.WarningCount, "Warning count");
        }

    }
}