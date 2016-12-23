namespace Infrastructure.File
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    public class FileHelper
    {
        public static void Create(string filePath,string content)
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
        /// Zip打包
        /// </summary>
        /// <param name="dictionary">字典（文件名、流）</param>
        /// <returns>打包后的流</returns>
        public static Stream ZipPackaging(IDictionary<string, Stream> dictionary)
        {
            Stream stream = new MemoryStream();

            return stream;
        }
    }
}
