namespace Core.Tests.ApplicationTest
{
    using Application.AppServices.VehicleAppservices;
    using Infrastructure.PDF;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new WordToPDF().SingleWordToPDF();
            Assert.IsTrue(true);
        }
    }
}
