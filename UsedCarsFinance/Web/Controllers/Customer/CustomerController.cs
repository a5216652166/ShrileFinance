namespace Web.Controllers.Customer
{
    using System;
    using System.Web.Http;
    using System.Collections.Generic;
    using Application;
    using Application.ViewModels.OrganizationViewModels;

    public class CustomerController : ApiController
    {
        private readonly OrganizationAppService customerAppService;
        private readonly StatisticsAppService treeGridService;
        private readonly ProcessTempDataAppService processTempDataAppService;

        public CustomerController(OrganizationAppService service,
            StatisticsAppService treeGridService,
            ProcessTempDataAppService processTempDataAppService
            )
        {
            customerAppService = service;
            this.treeGridService = treeGridService;
            this.processTempDataAppService = processTempDataAppService;
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// yand    16.10.30
        /// <param name="id">id</param>
        /// <returns></returns>
        public OrganizationViewModel Get(Guid id)
        {
            var org = customerAppService.Get(id);

            var orgStr = Newtonsoft.Json.JsonConvert.SerializeObject(org);

            return org;
        }

        public IHttpActionResult GetAll()
        {
            var cusCombo = customerAppService.GetAll();

            return Ok(cusCombo);
        }

        public IHttpActionResult GetOptions()
        {
            var options = customerAppService.GetOptions();

            return Ok(options);
        }

        /// <summary>
        /// 授信页面机构信息
        /// </summary>
        /// <param name="id">机构标识</param>
        /// <returns>机构信息</returns>
        public IHttpActionResult GetCreditOriagenizate(Guid id)
        {
            var creditOrganizate = customerAppService.GetCreditOrganizate(id);

            return Ok(creditOrganizate);
        }

        /// <summary>
        /// 查询带分页
        /// </summary>
        /// yand    16.10.30
        /// <param name="Search">筛选条件</param>
        /// <param name="page">页数</param>
        /// <param name="rows">每页显示行数</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetPageList(string Search, int page, int rows)
        {
            var list = customerAppService.GetPageList(Search, page, rows);

            return Ok(list);
        }
    }
}
