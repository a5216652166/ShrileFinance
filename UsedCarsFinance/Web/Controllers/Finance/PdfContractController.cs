﻿namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Models;

    public class PdfContractController : ApiController
    {
        private static readonly BLL.Contract.PdfContract contract = new BLL.Contract.PdfContract();

        /// <summary>
        /// 获取合同地址
        /// </summary>
        /// wangpf  16.08.04 修改
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        [HttpGet]
        public Models.Sys.FileInfo GetPath(int fileId)
        {
            return new BLL.Sys.File().Get(fileId);
        }

        /// <summary>
        /// 获取合同名称
        /// </summary>
        /// yand    16.05.16
        /// <param name="FinanceId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetContrantType(Guid FinanceId)
        {
            return new BLL.Contract.PdfContract().FindContrantName(FinanceId);
        }

        /// <summary>
        /// 测试,测试,测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Test(int id)
        {
            var _contract = new BLL.Contract.PdfContract();
            _contract.CreateContrant(id);
            return Ok();
        }
    }
}
