using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace BLL.Sys
{
    /// <summary>
    /// 下载压缩类
    /// </summary>
    public class Compress
    {
        //private string Path;
        private string zipfilepath;

        public Compress()
        {
            string path = @"~\Upload\Temps\" + System.Guid.NewGuid().ToString();
            string fullpath = HttpContext.Current.Server.MapPath(path);

            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

            zipfilepath = path;
        }

        /// <summary>
        /// 向文件夹里加文件
        /// </summary>
        /// cais    16.04.26
        /// <param name="fileinfo">文件信息</param>
        public void Add(Models.Sys.FileInfo fileinfo)
        {
            var Server = HttpContext.Current.Server;

            System.IO.File.Copy(
                Server.MapPath(fileinfo.FullName),
                Server.MapPath(zipfilepath + "\\" + fileinfo.NewName + fileinfo.ExtName),
                true
            );
        }

        /// <summary>
        /// 循环获取文件信息
        /// </summary>
        /// cais    16.04.27
        /// <param name="listfileinfo">文件信息</param>
        public void Add(List<Models.Sys.FileInfo> listfileinfo)
        {
            foreach (var file in listfileinfo)
            {
                Add(file);
            }
        }

        /// <summary>
        /// 压缩后的文件信息
        /// </summary>
        /// <returns></returns>
        public Models.Sys.FileInfo Comperssing()
        {
            string zippath = zipfilepath + ".zip";

            Models.Sys.FileInfo comperssFile = new Models.Sys.FileInfo();

            if (ZipFile(HttpContext.Current.Server.MapPath(zipfilepath), out string err) == true)
            {
                comperssFile.FilePath = zipfilepath;
                comperssFile.ExtName = ".zip";
            }

            return comperssFile;
        }

        /// <summary>
        /// 压缩文件方法
        /// </summary>
        /// cais    16.04.27
        /// <param name="dirPath">被压缩文件夹路径</param>
        /// <returns>压缩是否成功</returns>
        private bool ZipFile(string dirPath, out string err)
        {
            err = "";
            //压缩文件名为空时使用文件夹名＋.zip
            string zipFilePath = dirPath + ".zip";

            try
            {
                string[] filenames = Directory.GetFiles(dirPath);
                using (ZipOutputStream s = new ZipOutputStream(System.IO.File.Create(zipFilePath)))
                {
                    s.SetLevel(1);
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        var entry = new ZipEntry(Path.GetFileName(file))
                        {
                            DateTime = DateTime.Now
                        };
                        s.PutNextEntry(entry);
                        using (FileStream fs = System.IO.File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }
    }
}