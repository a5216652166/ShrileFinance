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

            throw new NotImplementedException();

            //return HttpHelper.DownLoad(fileName: keyValuePir.Key, stream: keyValuePir.Value);
        }

        [HttpGet]
        public IHttpActionResult Download()
        {
            //var FilePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/download/EditPlus64_xp85.com.zip");
            //var stream = new FileStream(FilePath, FileMode.Open);
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(stream);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
            //    FileName = "Wep Api Demo File.zip"
            //};

            //var text = $"Hello world!";

            //var client = new HttpClient();

            //var fileContent1 = new ByteArrayContent(Encoding.UTF8.GetBytes(text));
            //fileContent1.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") {
            //    FileName = $"file1.txt"
            //};

            //var fileContent2 = new ByteArrayContent(Encoding.UTF8.GetBytes(text));
            //fileContent2.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") {
            //    FileName = $"file2.txt"
            //};

            //var content = new MultipartFormDataContent();
            //content.Add(fileContent1);
            //content.Add(fileContent2);

            //var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            //response.Content = content;

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
