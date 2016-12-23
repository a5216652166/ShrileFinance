﻿namespace Web.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.AccountViewModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using global::Infrastructure.File;
    using global::Infrastructure.Http;

    public class TestController : ApiController
    {
        private readonly DatagramAppService service;

        public TestController(DatagramAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public HttpResponseMessage Generate(Guid id)
        {
            var keyValuePir = service.GenerateTest(id);

            return HttpHelper.DownLoad(fileName: keyValuePir.Key, stream: keyValuePir.Value);
        }

        [HttpGet]
        public IHttpActionResult Download()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult DownLoad()
        {
            string filePath = @"F:\android.txt";
            FileHelper.Create(filePath, "测试代码");
            HttpHelper.DownLoad(filePath);

            return Ok();
        }
    }
}
