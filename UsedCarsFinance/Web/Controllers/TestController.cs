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

    public class TestController : ApiController
    {
        private readonly MessageAppService service;

        public TestController(MessageAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult Generate()
        {
            service.Generate();

            return Ok();
        }
    }
}
