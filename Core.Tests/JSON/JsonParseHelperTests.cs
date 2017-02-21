namespace Infrastructure.JSON.Tests
{
    using System.Linq;
    using JSON;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JsonParseHelperTests
    {
        [TestMethod]
        public void GetJObjectTest()
        {
            var json = "{\"h\":\"Hello world!!!\",\"Array\":[\"A\",\"B\",\"C\"]}";

            var jsonObject = JsonParseHelper.GetJObject(json);

            Assert.IsTrue(jsonObject.Count == 2);
        }

        [TestMethod]
        public void GetJPropertiesTest()
        {
            var json = "{\"h\":\"Hello world!!!\",\"Array\":[\"A\",\"B\",\"C\"]}";

            var jsonProperties = JsonParseHelper.GetJProperties(json);

            Assert.IsTrue(jsonProperties.Count() == 2);
        }

        [TestMethod]
        public void GetJPropertyTest()
        {
            var json = "{\"h\":\"Hello world!!!\",\"Array\":[\"A\",\"B\",\"C\"]}";

            var jsonTokens = JsonParseHelper.GetJProperty(json, "Array", 2);

            Assert.IsTrue(jsonTokens.Count() == 3);
        }
    }
}