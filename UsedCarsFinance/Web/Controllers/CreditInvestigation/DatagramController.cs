namespace Web.Controllers.CreditInvestigation
{
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.CreditInvesitigation.TraceViewModels;
    using Application.ViewModels.Message;

    public class DatagramController : ApiController
    {
        private readonly DatagramAppService messageAppService;

        public DatagramController(DatagramAppService messageAppService)
        {
            this.messageAppService = messageAppService;
        }

        [HttpGet]
        public IHttpActionResult GetPageList(string search, int page, int rows)
        {
            var list = messageAppService.GetPageList(search, page, rows);

            return Ok(new PagedListViewModel<MessageTrackViewModel>(list));
        }

        [HttpPost]
        public IHttpActionResult ModifyName(ModifyNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            messageAppService.ModifyName(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Generate()
        {
            messageAppService.Generate();

            return Ok();
        }
    }
}
