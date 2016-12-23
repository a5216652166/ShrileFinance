namespace Infrastructure.File
{
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.IO.Compression;

    public class FileHelper
    {
        public static void Create(string filePath, string content)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                byte[] data = Encoding.Default.GetBytes(content);

                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
        }

        /// <summary>
        /// 压缩打包
        /// </summary>
        /// <param name="files">内存流集合</param>
        /// <returns>内存流</returns>
        public static MemoryStream Compression(IDictionary<string, MemoryStream> files)
        {
            var stream = new MemoryStream();

            using (var archive = new ZipArchive(
                stream, ZipArchiveMode.Create, true, Encoding.GetEncoding("GB2312")))
            {
                foreach (var file in files)
                {
                    var filename = file.Key;
                    var entry = archive.CreateEntry(filename, CompressionLevel.Fastest);

                    using (var entryStream = entry.Open())
                    using (var fileStream = file.Value)
                    {
                        var buffer = fileStream.ToArray();

                        entryStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            return stream;
        }
    }
}
