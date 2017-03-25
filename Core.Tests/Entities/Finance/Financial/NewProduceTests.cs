namespace Core.Tests.Entities.Finance.Financial
{
    using System.Linq;
    using Core.Entities.Finance.Financial;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Infrastructure.JSON;

    [TestClass]
    public class NewProduceTests
    {
        [TestMethod]
        public void CalculateRepayTableTest1()
        {
            var pv = 10000.00M;

            var rr = NewProduce.CreateInstance().CalculateRepayTable(pv);

            Assert.IsTrue(rr.Count() > 0);
        }
    }
}
