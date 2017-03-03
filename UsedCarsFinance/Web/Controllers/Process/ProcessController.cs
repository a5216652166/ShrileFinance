namespace Web.Controllers.Process
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.OrganizationViewModels;
    using Application.ViewModels.ProcessViewModels;
    using Core.Entities.Process;

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

            var processData = default(ProcessDataViewModel);

            try
            {
                processData = processAppService.GetProcessData(instanceId);

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
