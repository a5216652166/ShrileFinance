namespace Infrastructure.ValidMethod.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ValidMethod;

    [TestClass]
    public class TypeValidHelperTests
    {
        [TestMethod]
        public void IsOrganizationCodeTest()
        {
            var organizationCode = "76521929-0";

            var result = TypeValidHelper.IsOrganizationCode(organizationCode);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFinanceInstituteCodeTest()
        {
            var value = "33207991216";

            var result = TypeValidHelper.IsFinanceInstituteCode(value);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCreditCardCodeTest()
        {
            var value = "3405010000049227";

            var result = TypeValidHelper.IsCreditCardCode(value);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMoneyTest()
        {
            var value = "12.1";

            var result = TypeValidHelper.IsMoney(value);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsIdCardTest()
        {
            var value = "45112319710825646X";

            var result = TypeValidHelper.IsIdCard(value);

            Assert.IsTrue(result);
        }
    }
}