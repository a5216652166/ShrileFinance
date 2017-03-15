namespace Web.Controllers.Finance
{
    using System.Web.Http;
    using Application.AppServices.FinanceAppServices;
    using Application.ViewModels;
    using Application.ViewModels.FinanceViewModels;

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
    }
}
