namespace Core.Entities.IO
{
    using System;
    using System.IO;
    using System.Web;
    using Interfaces;

    public enum TableNameEnum : byte
    {
        申请人影像资料 = 1,
        放款影像资料 = 2
    }

    /// <summary>
    /// 文件封装
    /// </summary>
    public class FileSystem : Entity, IAggregateRoot
    {
        public const string VirtualPath = @"~\Upload\";

        public FileSystem()
        {
        }

        public FileSystem(string oldName, string extension, Stream stream = default(Stream), bool isTemp = false)
        {
            Id = Guid.Empty;
            OldName = oldName;
            Extension = extension;

            if (stream != default(Stream))
            {
                if (stream is MemoryStream)
                {
                    Stream = stream as MemoryStream;
                }
                else
                {
                    Stream = new MemoryStream();
                    stream.CopyTo(Stream);
                }
            }

            IsTemp = isTemp;
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; protected set; }

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
        public string Path { get; protected set; }

        /// <summary>
        /// 内存流
        /// </summary>
        public MemoryStream Stream { get; set; }

        /// <summary>
        /// 是否为临时文件
        /// </summary>
        public bool IsTemp { get; private set; }

        /// <summary>
        /// 文件创建时间
        /// </summary>
        public DateTime? DateOfCreate { get; set; }

        /// <summary>
        /// 引用标识
        /// </summary>
        public Guid? ReferenceId { get; set; }

        /// <summary>
        /// 分组标识
        /// </summary>
        public Guid? ReferenceSid { get; set; }

        /// <summary>
        /// 表单名
        /// </summary>
        public TableNameEnum? ReferenceType { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if (Stream == default(MemoryStream))
            {
                throw new ArgumentNullException(nameof(Stream), "流为null");
            }

            AllowName();

            // 文件所属文件夹路径（虚拟路径）
            var direct = IsTemp ? VirtualPath + @"Temps" : VirtualPath + DateTime.Now.ToString("yyyyMM");
            Path = direct + @"\" + Name + Extension;

            // 创建文件夹
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(direct));

            // 在文件夹下创建新文件，返回文件流
            var fs = File.Create(HttpContext.Current.Server.MapPath(Path));

            // 新文件写入内容
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
            if (Stream == default(MemoryStream))
            {
                var bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath(Path));

                Stream = new MemoryStream(bytes);
            }

            var memorySream = new MemoryStream();

            Stream.CopyTo(memorySream);

            return memorySream;
        }

        /// <summary>
        /// 分配文件名
        /// </summary>
        /// <param name="name">文件名</param>
        public void AllowName(string name = default(string))
        {
            if (string.IsNullOrEmpty(name))
            {
                Name = Guid.NewGuid().ToString();
            }
            else
            {
                Name = name;
            }
        }

        /// <summary>
        /// 分配路径
        /// </summary>
        /// <param name="path">路径</param>
        public void AllowPath(string path = default(string))
        {
            if (string.IsNullOrEmpty(path) == false)
            {
                Path = path;
            }
        }
    }
}
