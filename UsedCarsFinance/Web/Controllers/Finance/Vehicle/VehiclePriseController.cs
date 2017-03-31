namespace Web.Controllers.Finance.Vehicle
{    
    using System.Web.Http;
    using Application.AppServices.VehicleAppservices;

    public class VehiclePriseController : ApiController
    {
        private readonly VehicleAppService vehicleAppService;

        public VehiclePriseController(VehicleAppService vehicleAppService)
        {
            this.vehicleAppService = vehicleAppService;
        }
        
        [HttpGet]
        public object PostToGetVehiclePrise()
        {
            var ssss = vehicleAppService.PostToGetVehiclePrise("vfaytrc", "ssgwlgu");
            
            return Ok(ssss);
        }
    }
}
