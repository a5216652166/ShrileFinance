namespace Web.Controllers.Finance.Financial
{
    using System;
    using System.Web.Http;
    using Application.AppServices.FinanceAppServices;
    using Application.ViewModels;
    using Application.ViewModels.FinanceViewModels.ProduceViewModels;

    public class NewProduceController : ApiController
    {
        private readonly NewProduceAppService produceAppService;

        public NewProduceController(NewProduceAppService produceAppService)
        {
            this.produceAppService = produceAppService;
        }

        [HttpGet]
        public IHttpActionResult GetPageList(int page,int rows,string search)
        {
            var list = produceAppService.GetPageList(search, page, rows);

            return Ok(new PagedListViewModel<NewProduceListViewModel>(list));
        }

        [HttpGet]
        public IHttpActionResult Get(Guid produceId)
        {
            var model = produceAppService.Get(produceId);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(NewProduceViewModel model)
        {
            produceAppService.Create(model);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Modify(NewProduceViewModel model)
        {
            produceAppService.Modify(model);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult Options()
        {
           var options =  produceAppService.Options();

            return Ok(options);
        }
    }
}
