namespace Core.Tests.Entities.Finance.Financial
{
    using System.Linq;
    using Core.Entities.Finance.Financial;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NewProduceTests
    {
        [TestMethod]
        public void CalculateRepayTableTest1()
        {
            var pv = 10000.00M;

            var rr = Produce.CreateInstance().CalculateRepayTable(pv);

            Assert.IsTrue(rr.Count() > 0);
        }
    }
}
