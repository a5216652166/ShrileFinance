using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.ValidMethod.Tests
{
    [TestClass()]
    public class TypeValidHelperTests
    {
        [TestMethod()]
        public void IsOrganizationCodeTest()
        {
            var organizationCode = "76521929-0";

            var result = organizationCode.IsOrganizationCode();

            Assert.IsTrue(result);
        }
    }
}