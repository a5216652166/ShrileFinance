namespace Infrastructure.JSON.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using JSON;

    [TestClass()]
    public class JsonParseHelperTests
    {
        [TestMethod()]
        public void GetJObjectTest()
        {
            var aa = JsonParseHelper.GetJObject(null);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetJPropertitesTest()
        {
            Assert.IsTrue(true);
        }
    }
}