namespace Infrastructure.Http
{
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
        /// <param name="fileInfo">文件</param>
        /// <returns>Http响应</returns>
        public static HttpResponseMessage DownLoad(FileInfo fileInfo)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            try
            {
                FileStream fs = new FileStream(fileInfo.FullName,FileMode.Open);

                //var fs = (new FileInfo("D:1234.txt")).OpenRead();

                response.Content = new StreamContent(fs);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileInfo.Name,
                    FileNameStar = fileInfo.Name
                };
            }
            catch(System.Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            return response;
        }
    }
}
