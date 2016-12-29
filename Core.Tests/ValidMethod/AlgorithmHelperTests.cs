namespace Infrastructure.ValidMethod.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Infrastructure.ValidMethod;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass()]
    public class AlgorithmHelperTests
    {
        [TestMethod()]
        public void LulnMethodTest()
        {
            var luln = "79927398713";

            var result = luln.LulnMethod();

            Assert.IsTrue(result.Key);
        }
    }
}