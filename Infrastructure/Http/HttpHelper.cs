using System.IO;
using System.Text;
using System.Web;

namespace Infrastructure.Http
{
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
    }
}
