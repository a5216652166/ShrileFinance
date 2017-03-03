namespace Web.Controllers.Process
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.OrganizationViewModels;
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

            var processType = processAppService.GetProcessType(instanceId);

            switch (processType)
            {
                default:
                    throw new ArgumentException("该流程实例的类型不存在");
                case ProcessTypeEnum.融资:
                    httpActionResult = GetProcessDataForFinance(instanceId);
                    break;
                case ProcessTypeEnum.添加机构:
                    httpActionResult = GetProcessDataForOrganization(instanceId);
                    break;
                case ProcessTypeEnum.授信:
                    httpActionResult = GetProcessDataForCredit(instanceId);
                    break;
                case ProcessTypeEnum.借据:
                    httpActionResult = GetProcessDataForLoan(instanceId);
                    break;
                case ProcessTypeEnum.还款:
                    httpActionResult = GetProcessDataForPayment(instanceId);
                    break;
                case ProcessTypeEnum.机构变更:
                    httpActionResult = GetProcessDataForOrganizationModify(instanceId);
                    break;
            }

            return httpActionResult;
        }

        private IHttpActionResult GetProcessDataForFinance(Guid instanceId)
        {
            return null;
        }

        private IHttpActionResult GetProcessDataForOrganization(Guid instanceId)
        {
            return null;
        }

        private IHttpActionResult GetProcessDataForCredit(Guid instanceId)
        {
            return null;
        }

        private IHttpActionResult GetProcessDataForLoan(Guid instanceId)
        {
            return null;
        }

        private IHttpActionResult GetProcessDataForPayment(Guid instanceId)
        {
            return null;
        }

        private IHttpActionResult GetProcessDataForOrganizationModify(Guid instanceId)
        {
            var organizationChangeViewModel = processTempDataAppService.GetByInstanceId<OrganizationChangeViewModel>(instanceId);

            if (organizationChangeViewModel == null)
            {
                return BadRequest();
            }

            return Ok(organizationChangeViewModel.ObjData);
        }
    }
}
