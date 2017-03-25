namespace Core.Tests.InfrastructureTest.JSON.Tests
{
    using Infrastructure.JSON;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntityCloneHelperTests
    {
        [TestMethod]
        public void CloneTest()
        {
            var obj = new TestClass(1, "A");

            var newObj = EntityCloneHelper.Clone(obj);

            var result = obj != newObj && newObj.Num == 1 && newObj.Value == "A";

            Assert.IsTrue(result);
        }

        private class TestClass
        {
            public TestClass(int num, string value)
            {
                Num = num;
                Value = value;
            }

            public int Num { get; set; }

            public string Value { get; set; }
        }
    }
}