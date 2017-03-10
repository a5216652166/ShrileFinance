namespace Web.Controllers
{
    using System.IO;
    using System.Web.Http;
    using Application;

    public class TestController : ApiController
    {
        private readonly DatagramAppService datagramAppService;
        private readonly FileSystemAppService fileSystemAppService;

        public TestController(DatagramAppService datagramAppService, FileSystemAppService fileSystemAppService)
        {
            this.datagramAppService = datagramAppService;
            this.fileSystemAppService = fileSystemAppService;
        }

        ////[HttpGet]
        ////public IHttpActionResult Download()
        ////{
        ////    var text = $"Hello world!";
        ////    var files = new Dictionary<string, MemoryStream>();

        ////    for (int i = 0; i < 3; i++)
        ////    {
        ////        var stream = new MemoryStream();
        ////        var buffer = Encoding.GetEncoding("GB2312").GetBytes(text);

        ////        stream.Write(buffer, 0, buffer.Length);

        ////        files.Add($"file{i}.txt", stream);
        ////    }

        ////    var result = Helper.Compression(files);

        ////    var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
        ////    response.Content = new ByteArrayContent(result.GetBuffer());
        ////    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") {
        ////        FileName = $"test.zip"
        ////    };

        ////    return ResponseMessage(response);
        ////}

        [HttpGet]
        public IHttpActionResult FileSysTest()
        {
            var file = new FileInfo(@"F:/aaa.txt");

            var fileSys = fileSystemAppService.CreatFile(file);

            var files = fileSystemAppService.GetAll();

            return Ok();
        }
    }
}
