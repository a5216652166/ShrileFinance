﻿namespace Infrastructure.Http
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Web;

    public class HttpHelper
    {
        public static void DownLoad(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);

            HttpResponse response = HttpContext.Current.Response;

            response.ContentType = "application/octet-stream";

            // 通知浏览器下载文件,而不是打开文件
            response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filePath, Encoding.UTF8));
            response.BinaryWrite(bytes);

            fs.Close();
            response.Flush();
            response.End();
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="file">文件信息</param>
        /// <returns>http响应</returns>
        public static HttpResponseMessage Download(KeyValuePair<string, MemoryStream> file)
        {
            var byteArrayContent = new ByteArrayContent(file.Value.GetBuffer());

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = byteArrayContent;
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = file.Key
            };

            return response;
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="file">文件信息</param>
        /// <returns>http响应</returns>
        public static HttpResponseMessage Download(KeyValuePair<string, byte[]> file)
        {
            var byteArrayContent = new ByteArrayContent(file.Value);

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = byteArrayContent;
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = file.Key
            };

            return response;
        }
    }
}
