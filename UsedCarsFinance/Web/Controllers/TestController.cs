namespace Web.Controllers
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using Application;
    using System.IO;
    using System.Collections.Generic;
    using global::Infrastructure;
    using global::Infrastructure.Http;

    public class TestController : ApiController
    {
        private readonly DatagramAppService service;

        public TestController(DatagramAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult Download()
        {
            var text = $"Hello world!";
            var files = new Dictionary<string, MemoryStream>();

            for (int i = 0; i < 3; i++)
            {
                var stream = new MemoryStream();
                var buffer = Encoding.GetEncoding("GB2312").GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);

                files.Add($"file{i}.txt", stream);
            }

            var result = Helper.Compression(files);

            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            response.Content = new ByteArrayContent(result.GetBuffer());
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") {
                FileName = $"test.zip"
            };

            return ResponseMessage(response);
        }
    }
}
