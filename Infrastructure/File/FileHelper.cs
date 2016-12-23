
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Infrastructure.File
{
    public class FileHelper
    {
        public static void Create(string filePath,string content)
        {
            if (!System.IO.File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                byte[] data = Encoding.Default.GetBytes(content);

                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
        }
    }
}
