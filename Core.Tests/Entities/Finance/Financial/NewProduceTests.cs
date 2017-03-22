

namespace Core.Tests.Entities.Finance.Financial
{
    using Core.Entities.Finance.Financial;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NewProduceTests
    {
        [TestMethod]
        public void CalculateRepayTableTest1()
        {
            var pv = 10000.00M;

            var rr = NewProduce.Create().CalculateRepayTable(pv);

            Assert.IsTrue(true);
        }
    }
}
