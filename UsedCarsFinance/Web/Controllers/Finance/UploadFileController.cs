namespace Web.Controllers.Finance
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.FinanceViewModels;
    using Core.Entities.IO;
    using global::Infrastructure.Http;

    public class UploadFileController : ApiController
    {
        private readonly FinanceAppService financeAppService;
        private readonly FileSystemAppService fileSystemAppService;

        public UploadFileController(FinanceAppService financeAppService, FileSystemAppService fileSystemAppService)
        {
            this.financeAppService = financeAppService;
            this.fileSystemAppService = fileSystemAppService;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Upload()
        {
            if (Request.Content.IsMimeMultipartContent() == false)
            {
                return BadRequest("不支持的媒体类型!");
            }

            var files = HttpContext.Current.Request.Files;

            var referenceId = Guid.Parse(HttpContext.Current.Request.Form["ReferenceId"]);
            var tableName = Convert.ToInt32(HttpContext.Current.Request.Form["TableName"]);
            var referencedSid = Guid.Parse(HttpContext.Current.Request.Form["ReferencedSid"]);

            fileSystemAppService.CreatFile(files, referenceId, referencedSid, (TableNameEnum)tableName);

            return Ok(new { referenceId = referenceId, filesCount = files.Count, tableName = tableName, referencedSid = referencedSid });
        }

        /// <summary>
        /// 通过引用标识和表单名获取文件
        /// </summary>
        /// <param name="rId">引用标识</param>
        /// <param name="tableName">表单名</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAll(Guid rId, TableNameEnum tableName)
        {
            var list = fileSystemAppService.GetAll(rId, tableName);

            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetFiles(Guid referenceId, TableNameEnum tableName, Guid referencedSid)
        {
            var list = fileSystemAppService.GetAll(referenceId, tableName,new List<Guid?>() { referencedSid } );

            return Ok(list);
        }


        /// <summary>
        /// 通过引用标识和表单名删除文件
        /// </summary>
        /// <param name="value">引用标识</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteAll(UploadViewModel value)
        {
            var result = fileSystemAppService.DeleteAll(value.ReferenceId, value.TableName, value.ReferencedSids);

            return Ok(result);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="tableName">表单名</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DownloadAllFile(UploadViewModel value)
        {
            var list = fileSystemAppService.GetAll(value.ReferenceId, value.TableName,value.ReferencedSids);

            var stream = fileSystemAppService.Compression(list);

            var file = new KeyValuePair<string, MemoryStream>(DateTime.Now.ToShortDateString() + ".zip", stream);

            try
            {
                return HttpHelper.Download(file);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, ex);
            }
        }

        /// <summary>
        /// 下载单身证明
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>单身证明</returns>
        [HttpGet]
        public HttpResponseMessage DownloadFiles(Guid financeId, int sign)
        {
            var file = financeAppService.DownloadFiles(financeId, sign);

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
