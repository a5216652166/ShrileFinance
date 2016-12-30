namespace Core.Entities.IO
{
    using System;
    using System.IO;
    using Interfaces;

    /// <summary>
    /// 文件封装
    /// </summary>
    public class FileSystem : Entity, IAggregateRoot
    {
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

        public FileSystem(string name, string extension, Stream stream = null, bool isTemp = false)
        {
            OldName = name;
            Extension = extension;

            if (stream != null)
            {
                Stream = new MemoryStream();
                stream.CopyTo(Stream);
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
            // 清除临时文件
            if (IsTemp && File.Exists(Path))
            {
                File.Delete(Path);

                return;
            }

            if (Stream == null)
            {
                throw new IOException("流为null");
            }

            // 文件所属文件夹
            var dirPath = DateTime.Now.ToString("yyyyMM");

            Directory.CreateDirectory(dirPath);

            // 设置文件路径
            Path = dirPath + GenerateName() + Extension;

            var fileInfo = new FileInfo(dirPath);
            var fileSream = fileInfo.OpenWrite();

            Stream.CopyTo(fileSream);

            fileSream.Flush();
            fileSream.Dispose();
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
