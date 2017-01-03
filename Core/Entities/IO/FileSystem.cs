namespace Core.Entities.IO
{
    using System;
    using System.IO;
    using System.Web;
    using Interfaces;

    /// <summary>
    /// 文件封装
    /// </summary>
    public class FileSystem : Entity, IAggregateRoot
    {
        private const string VirtualPath = @"~\Files\";
        public FileSystem()
        {
            if (!string.IsNullOrEmpty(Path) && File.Exists(Path))
            {
                var fileStream = File.OpenRead(Path);

                Stream = new MemoryStream();

                fileStream.CopyTo(Stream);

                fileStream.Flush();
                fileStream.Dispose();
            }
        }

        public FileSystem(string oldName, string extension, Stream stream = null, bool isTemp = false)
        {
            OldName = oldName;
            Extension = extension;

            if (stream != null)
            {
                if (stream is MemoryStream)
                {
                    Stream = stream as MemoryStream;
                }
                else
                {
                    Stream = Stream ?? new MemoryStream();

                    stream.CopyTo(Stream);
                }
            }

            IsTemp = isTemp;
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string OldName { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 流
        /// </summary>
        public MemoryStream Stream { get; set; }

        /// <summary>
        /// 是否为临时文件
        /// </summary>
        public bool IsTemp { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if (Stream == null)
            {
                throw new IOException("流为null");
            }

            Name = GenerateName();

            // 文件所属文件夹
            var direct = IsTemp ? VirtualPath + @"Temps" : VirtualPath + DateTime.Now.ToString("yyyyMM");
            Path = direct + @"\" + Name + Extension;

            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(direct));

            var fs = File.Create(HttpContext.Current.Server.MapPath(Path));

            var buffer = Stream.ToArray();
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Dispose();
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns>内存流</returns>
        public MemoryStream Read()
        {
            if (Stream == null)
            {
                throw new IOException("流为null");
            }

            var memorySream = new MemoryStream();

            Stream.CopyTo(memorySream);

            return memorySream;
        }

        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <returns>新文件名</returns>
        private string GenerateName()
        {
            Name = Guid.NewGuid().ToString();

            return Name;
        }
    }
}
