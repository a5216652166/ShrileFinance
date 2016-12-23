﻿namespace Web.Controllers.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
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
        public IHttpActionResult GetPageList(string search, int page, int rows, TraceStatusEmum? status = null)
        {
            var list = messageAppService.GetPageList(search, page, rows, status);

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
        public HttpResponseMessage Download(DownloadViewModel ids)
        {
            try
            {
                var file = messageAppService.DownloadZip(ids);

                var byteArrayContent = new ByteArrayContent(file.Value.GetBuffer());
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = byteArrayContent;
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = file.Key
                };

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }
}

