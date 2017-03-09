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

        /////// <summary>
        /////// 提交
        /////// </summary>
        /////// yand    16.10.25
        /////// <param name="value">机构信息</param>
        /////// <returns>处理结果</returns>
        ////[HttpPost]
        ////public IHttpActionResult Add(OrganizationViewModel value)
        ////{
        ////    if (!ModelState.IsValid)
        ////    {
        ////        return BadRequest(ValidModel.ShowErrorFirst(ModelState));
        ////    }

        ////    customerAppService.Create(value);

        ////    return Ok();
        ////}

        /////// <summary>
        /////// 修改
        /////// </summary>
        /////// yand    16.10.25
        /////// <param name="value">机构信息</param>
        /////// <returns>处理结果</returns>
        ////public IHttpActionResult Modify(OrganizationViewModel value)
        ////{
        ////    if (!ModelState.IsValid)
        ////    {
        ////        return BadRequest(ModelState);
        ////    }

        ////    ////var orgStr = "{\"Base\":{\"Id\":\"05f66aba-29a0-e611-80c5-507b9de4a488\",\"CustomerNumber\":\"21342135\",\"ManagementerCode\":\"234234234\",\"CustomerType\":\"2\",\"InstitutionCreditCode\":\"213423434\",\"OrganizateCode\":null,\"RegistraterType\":\"02\",\"RegistraterCode\":\"324\",\"TaxpayerIdentifyIrsNumber\":\"234\",\"TaxpayerIdentifyLandNumber\":\"324\",\"LoanCardCode\":\"1111111111111111\",\"HasParent\":false},\"Property\":{\"InstitutionChName\":\"测试\",\"RegisterAddress\":\"123\",\"RegisterAdministrativeDivision\":null,\"SetupDate\":\"2016-11-28T00:00:00\",\"CertificateDueDate\":\"2016-11-10T00:00:00\",\"BusinessScope\":\"123\",\"RegisterCapital\":123.12,\"OrganizationCategory\":\"2\",\"OrganizationCategorySubdivision\":\"13\",\"EconomicSectorsClassification\":\"c\",\"EconomicType\":\"11\"},\"State\":{\"EnterpriseScale\":\"4\",\"InstitutionsState\":\"9\"},\"Contact\":{\"OfficeAddress\":\"123\",\"ContactPhone\":\"123\",\"FinancialContactPhone\":\"123\"},\"Managers\":[],\"Shareholders\":[{\"Id\":\"0ef66aba-29a0-e611-80c5-507b9de4a488\",\"ShareholdersType\":\"1\",\"ShareholdersName\":\"123\",\"RegistraterType\":\"1\",\"RegistraterCode\":\"123\",\"OrganizateCode\":null,\"InstitutionCreditCode\":\"123123123123\",\"SharesProportion\":12.12,\"FamilyMembers\":[{\"Id\":\"0ff66aba-29a0-e611-80c5-507b9de4a488\",\"Relationship\":\"4\",\"Name\":\"123\",\"CertificateType\":\"4\",\"CertificateCode\":\"123\"}]}],\"AssociatedEnterprises\":[{\"Id\":\"06f66aba-29a0-e611-80c5-507b9de4a488\",\"AssociatedType\":\"22\",\"Name\":\"123\",\"RegistraterType\":\"01\",\"RegistraterCode\":\"1123\",\"OrganizateCode\":null,\"InstitutionCreditCode\":\"111111111111111111\"}],\"Parent\":null,\"FinancialAffairs\":{\"Year\":2016,\"TypeSubdivision\":1,\"AuditFirm\":\"12\",\"AuditorName\":\"32\",\"CashFlow\":[],\"Liabilities\":[],\"Profit\":[{\"Type\":0,\"BusinessIncome\":123.34,\"OperatingCost\":0.00,\"SalesTax\":0.00,\"SellingExpenses\":0.00,\"ManagementExpenses\":0.00,\"FinancialExpenses\":123.34,\"AssetsimpairmentLoss\":0.00,\"FairIncome\":0.00,\"NetInvestmentIncome\":0.00,\"EnterpriseInvestmentIncome\":0.00,\"OperatingProfit\":123.34,\"OperatingIncome\":0.00,\"OperatingExpenditure\":0.00,\"NonCurrentAssetsLoss\":0.00,\"GrossProfit\":123.34,\"IncomeTaxExpense\":0.00,\"NetProfit\":123.34,\"BasicEarningsShare\":0.00,\"DilutedEarningsShare\":0.00}],\"IncomeExpenditur\":[],\"InstitutionLiabilities\":[]},\"Litigation\":[{\"ChargedSerialNumber\":\"123123\",\"ProsecuteName\":\"123123\",\"Money\":123.12,\"DateTime\":\"2016-11-29T00:00:00\",\"Result\":\"123123\",\"Reason\":\"123123123\"},{\"ChargedSerialNumber\":\"12312\",\"ProsecuteName\":\"123\",\"Money\":123123.12,\"DateTime\":\"2016-11-22T00:00:00\",\"Result\":\"123123\",\"Reason\":\"123123\"}],\"BigEvent\":[{\"BigEventNumber\":\"12312\",\"BigEventDescription\":\"312312\"}]}";

        ////    ////value = Newtonsoft.Json.JsonConvert.DeserializeObject<OrganizationViewModel>(orgStr);

        ////    customerAppService.Modify(value);

        ////    return Ok();
        ////}

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
