namespace Web.Controllers.Finance.Financial
{
    using System;
    using System.Web.Http;
    using Application.AppServices.FinanceAppServices.FinancialAppServices;
    using Application.ViewModels;
    using Application.ViewModels.FinanceViewModels.FinancialLoanViewModels.ProduceViewModels;

    public class ProduceController : ApiController
    {
        private readonly ProduceAppService produceAppService;

        public ProduceController(ProduceAppService produceAppService)
        {
            this.produceAppService = produceAppService;
        }

        [HttpGet]
        public IHttpActionResult GetPageList(int page = 1, int rows = 1, string search = "")
        {
            var list = produceAppService.GetPageList(search, page, rows);

            return Ok(new PagedListViewModel<ProduceListViewModel>(list));
        }

        [HttpGet]
        public IHttpActionResult Get(Guid produceId)
        {
            var model = produceAppService.Get(produceId);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(ProduceViewModel model)
        {
            produceAppService.Create(model);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Modify(ProduceViewModel model)
        {
            produceAppService.Modify(model);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult Options()
        {
            var options = produceAppService.Options();

            return Ok(options);
        }

        [HttpGet]
        public IHttpActionResult LoadRepayTable(Guid produceId, decimal pV)
            => Ok(produceAppService.LoadRepayTable(produceId, pV));
    }
}
