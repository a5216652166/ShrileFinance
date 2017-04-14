namespace Web.Controllers.External
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Application.AppServices.ExternalAppServices;
    using Application.AppServices.VehicleAppservices;

    [AllowAnonymous]
    public class HuaaoController : ApiController
    {
        private readonly HuaaoAppService service;
        private readonly VehicleAppService vehicleService;

        public HuaaoController(
            HuaaoAppService service,
            VehicleAppService vehicleService)
        {
            this.service = service;
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        public IHttpActionResult GetBailInfo(string partnerName, string identity, string identityType, string frameNo)
        {
            var finance = service.GetFinance(partnerName, identity, frameNo);

            if (finance == null)
            {
                return NotFound();
            }

            var applicant = finance.Applicant.FirstOrDefault(m => m.Type == Core.Entities.Finance.Applicant.TypeEnum.主要申请人);
            var vehicle = vehicleService.Get(finance.Vehicle.VehicleKey);

            return Ok(new {
                Id = finance.Id,
                Make = vehicle.Make,
                Series = vehicle.Series,
                Vehicle = vehicle.Vehicle,
                ApplicantName = applicant.Name,
                ApplicantPhone = applicant.Mobile,
                Bail = finance.GetBail()
            });
        }

        [HttpGet]
        public IHttpActionResult IdentityTypeOptions()
        {
            var options = new List<string>
            {
                "身份证",
                "居住证",
                "户口本",
                "机动车驾驶证",
                "军官证",
                "签证",
                "护照"
            };

            return Ok(options.Select(m => new { value = m, text = m }));
        }

        [HttpGet]
        public IHttpActionResult PayBail(Guid id)
        {
            service.PayBail(id);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult RevertBail(Guid id)
        {
            service.RevertBail(id);

            return Ok();
        }
    }
}
