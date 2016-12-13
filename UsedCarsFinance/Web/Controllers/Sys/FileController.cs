namespace Web.Controllers.Sys
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Http;

    [RoutePrefix("download")]
    public class FileController : ApiController
    {
        private static readonly BLL.Sys.File _file = new BLL.Sys.File();

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// qiy		16.04.05
        /// <param name="fileId">文件标识</param>
        /// <returns></returns>
        [HttpGet]
        public Models.Sys.FileInfo Get(int fileId)
        {
            return _file.Get(fileId);
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// qiy		16.04.05
        /// <param name="referenceId">引用标识</param>
        /// <returns></returns>
        [HttpGet]
        public List<Models.Sys.FileInfo> List(int referenceId)
        {
            return _file.GetByReference(referenceId);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// qiy     16.04.06
        /// <param name="fileId">文件标识</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get_demo_file")]
        public HttpResponseMessage Download(int fileId)
        {
            HttpResponseMessage response = Request.CreateResponse();

            Models.Sys.FileInfo file = _file.Get(fileId);
            string fullname = HttpContext.Current.Server.MapPath(file.FullName);

            if (File.Exists(fullname))
            {
                response.StatusCode = HttpStatusCode.OK;

                FileStream stream = new System.IO.FileStream(
                    fullname,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read
                );

                response.Headers.AcceptRanges.Add("bytes");
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = file.FileName;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentLength = stream.Length;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }

            return response;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// qiy		16.04.05
        /// <param name="referenceId">引用标识</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Upload()
        {
            string message = string.Empty;

            if (!Request.Content.IsMimeMultipartContent())
                return BadRequest("不支持的媒体类型!");

            var referenceId = Convert.ToInt32(HttpContext.Current.Request.Form["ReferenceId"]);

            bool result = _file.Add(HttpContext.Current.Request.Files, referenceId, out message);

            if (message != "")
                return BadRequest("文件格式不合法!");

            return result ? (IHttpActionResult)Ok() : BadRequest("引用标识不正确");
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// qiy		16.04.05
        /// <param name="fileId">文件标识</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int fileId)
        {
            _file.Delete(fileId);

            return Ok();
        }

        /// <summary>
        /// 批量删除文件
        /// </summary>
        /// qiy		16.04.05
        /// <param name="referenceId">引用标识</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteByReference(Guid referenceId)
        {
            _file.DeleteByReference(referenceId);

            return Ok();
        }

        /// <summary>
        /// 下载文件流
        /// </summary>
        /// <param name="fileinfo">压缩后的文件信息</param>
        /// <returns>下载文件流</returns>
        [HttpGet]
        [Route("get_demo_file")]
        public HttpResponseMessage GetDownloadResponse(Models.Sys.FileInfo fileinfo)
        {
            try
            {
                string filename = fileinfo.FilePath + fileinfo.ExtName;
                var FilePath = System.Web.Hosting.HostingEnvironment.MapPath(filename);
                string ResponseFileName = "图片压缩包.zip";

                var stream = new FileStream(FilePath, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = ResponseFileName,
                    FileNameStar = ResponseFileName
                };

                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
    }
}