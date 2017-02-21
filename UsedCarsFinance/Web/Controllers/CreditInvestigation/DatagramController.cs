namespace Web.Controllers.CreditInvestigation
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.CreditInvesitigation.TraceViewModels;
    using Core.Entities.CreditInvestigation;
    using global::Infrastructure.Http;

    public class DatagramController : ApiController
    {
        private readonly DatagramAppService messageAppService;

        public DatagramController(DatagramAppService messageAppService)
        {
            this.messageAppService = messageAppService;
        }

        [HttpGet]
        public IHttpActionResult GetPageList(string search, int page, int rows, TraceStatusEmum? status = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var list = messageAppService.GetPageList(search, page, rows, status, beginTime, endTime);

            var result = new PagedListViewModel<TraceViewModel>(list);

            return Ok(new PagedListViewModel<TraceViewModel>(list));
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

        [HttpPost]
        public IHttpActionResult Generate(GenerateViewModel traceIds)
        {
            messageAppService.Generate(traceIds.Ids);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Rebuid(GenerateViewModel traceIds)
        {
            messageAppService.Rebuid(traceIds.Ids);

            return Ok();
        }

        [HttpPost]
        public HttpResponseMessage Download(DownloadViewModel ids)
        {
            var file = messageAppService.Download(ids);

            try
            {
                return HttpHelper.Download(file);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, ex);
            }
        }
    }
}

