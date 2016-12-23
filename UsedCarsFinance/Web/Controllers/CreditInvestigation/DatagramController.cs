namespace Web.Controllers.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.CreditInvesitigation.TraceViewModels;
    using global::Infrastructure.Http;

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

        [HttpGet]
        public HttpResponseMessage Download(Guid id)
        {
            var keyValuePir = messageAppService.Download(id);

            return HttpHelper.DownLoad(fileName: keyValuePir.Key, stream: keyValuePir.Value);
        }

        [HttpPost]
        public HttpResponseMessage Download(List<Guid> ids)
        {
            var keyValuePir = messageAppService.DownloadZip(ids);

            var byteArrayContent = new ByteArrayContent((keyValuePir.Value as MemoryStream).GetBuffer());

            return HttpHelper.DownLoad(fileName: keyValuePir.Key, stream: byteArrayContent);
        }
    }
}

