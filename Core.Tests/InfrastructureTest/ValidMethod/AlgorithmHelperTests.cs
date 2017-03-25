namespace Core.Tests.InfrastructureTest.ValidMethod.Tests
{
    using Infrastructure.ValidMethod;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AlgorithmHelperTests
    {
        [TestMethod]
        public void LulnMethodTest()
        {
            var luln = "79927398713";

            var result = luln.LulnMethod();

            Assert.IsTrue(result.Key);
        }

        [TestMethod]
        public void MD5Encrypt_16bitTest()
        {
            var value = "BB42BEE105A4E61180C5507B9DE4A488";

            var result = AlgorithmHelper.MD5Encrypt_16bit(value).Equals("9F7AE4BFED064CE4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MD5Encrypt_32bitTest()
        {
            var value = "BB42BEE105A4E61180C5507B9DE4A488";

            var result = AlgorithmHelper.MD5Encrypt_32bit(value).Equals("85056C1E9F7AE4BFED064CE4295A572C");

            Assert.IsTrue(result);
        }
    }
}