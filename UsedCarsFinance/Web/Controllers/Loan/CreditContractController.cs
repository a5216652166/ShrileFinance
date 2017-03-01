namespace Web.Controllers
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.Loan.CreditViewModel;

    public class CreditContractController : ApiController
    {
        private readonly CreditContractAppService creditContractAppService;

        public CreditContractController(CreditContractAppService creditContractAppService)
        {
            this.creditContractAppService = creditContractAppService;
        }

        [HttpPost]
        public IHttpActionResult Create(CreditContractViewModel model)
        {
            creditContractAppService.Create(model);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Modify(CreditContractViewModel model)
        {
            creditContractAppService.Modify(model);

            return Ok();
        }

        public IHttpActionResult Get(Guid id)
        {
            var creditContract = creditContractAppService.Get(id);

            return Ok(creditContract);
        }

        public IHttpActionResult GetCreditBalance(Guid id, decimal limit)
        {
            var getCreditBalanc = creditContractAppService.GetCreditBalanc(id, limit);

            return Ok(getCreditBalanc);
        }

        [HttpGet]
        public IHttpActionResult Option()
        {
            return Ok(creditContractAppService.Option());
        }

        [HttpGet]
        public IHttpActionResult GetPageList(int page, int rows, string Search)
        {
            var list = creditContractAppService.GetPageList(Search, page, rows);

            return Ok(new PagedListViewModel<CreditContractViewModel>(list));
        }

        [HttpGet]
        public IHttpActionResult CheckCreditContractNumber(string creditContractNumber)
        {
            var result = creditContractAppService.CheckCreditContractNumber(creditContractNumber);

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult ChangeLimit(decimal limit, Guid id)
        {
            creditContractAppService.ChangeLimit(limit, id);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult StopStatus(Guid id)
        {
            creditContractAppService.StopStatus(id);

            return Ok();
        }
    }
}
