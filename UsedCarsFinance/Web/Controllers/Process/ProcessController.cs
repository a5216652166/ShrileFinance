namespace Web.Controllers.Process
{
    using System;
    using System.Web.Http;
    using Application;

    public class ProcessController : ApiController
    {
        private readonly ProcessAppService processAppService;
        private readonly ProcessTempDataAppService processTempDataAppService;

        public ProcessController(
            ProcessAppService processAppService,
            ProcessTempDataAppService processTempDataAppService)
        {
            this.processAppService = processAppService;
            this.processTempDataAppService = processTempDataAppService;
        }

        [HttpGet]
        public IHttpActionResult GetProcessData(Guid instanceId)
        {
            var httpActionResult = default(IHttpActionResult);

            try
            {
                var processData = processAppService.GetProcessData(instanceId);

                httpActionResult = Ok(processData);
            }
            catch (Exception ex)
            {
                httpActionResult = BadRequest(ex.Message);
            }

            return httpActionResult;
        }
    }
}
