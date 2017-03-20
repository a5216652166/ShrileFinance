namespace Web.Controllers.Finance.Financial
{
    using System;
    using System.Web.Http;
    using Application.AppServices.FinanceAppServices;
    using Application.ViewModels;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels;

    public class FinancialLoanController : ApiController
    {
        private readonly FinancialLoanAppService financialLoanAppService;

        public FinancialLoanController(FinancialLoanAppService financialLoanAppService)
        {
            this.financialLoanAppService = financialLoanAppService;
        }

        [HttpGet]
        public IHttpActionResult GetPageList(int page, int rows, string search)
        {
            var list = financialLoanAppService.GetPageList(search, page, rows);

            return Ok(new PagedListViewModel<FinancialLoanListViewModel>(list));
        }

        [HttpGet]
        public IHttpActionResult Get(Guid loanId)
        {
            var model = financialLoanAppService.Get(loanId);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(FinancialLoanViewModel model)
        {
            financialLoanAppService.Create(model);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Modify(FinancialLoanViewModel model)
        {
            financialLoanAppService.Modify(model);

            return Ok(model);
        }
    }
}
