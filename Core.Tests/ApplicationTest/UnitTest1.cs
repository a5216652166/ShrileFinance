namespace Core.Tests.ApplicationTest
{
    using Application.AppServices.VehicleAppservices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new VehicleAppService().PostToGetVehiclePrise("vfaytrc", "ssgwlgu", string.Empty, string.Empty, string.Empty, string.Empty);
            Assert.IsTrue(true);
        }
    }
}
