namespace Web.Controllers.Message
{
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.Message;

    public class MessageController : ApiController
    {
        private readonly MessageAppService messageAppService;

        public MessageController(MessageAppService messageAppService)
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
        public IHttpActionResult Modify(MessageTrackViewModel model)
        {
            messageAppService.Modify(model);

            return Ok();
        }
    }
}
