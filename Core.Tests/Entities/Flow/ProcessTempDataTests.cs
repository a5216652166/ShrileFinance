namespace Core.Entities.Tests
{
    using System.Collections.Generic;
    using Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProcessTempDataTests
    {
        private ProcessTempData processTempData = new ProcessTempData();

        [TestMethod]
        public void ConvertToObjectTest()
        {
            var list = new List<int>() { 9, 99 };

            processTempData.ConvertToJsonData(list);

            Assert.IsTrue(processTempData.JsonData == "[9,99]");
        }

        [TestMethod]
        public void ConvertToJsonDataTest()
        {
            var jsonData = "[9,99]";

            processTempData.JsonData = jsonData;

            var list = processTempData.ConvertToObject<List<int>>();

            Assert.IsTrue(list.Count==2 && list[0] == 9 && list[1] == 99);
        }
    }
}