namespace Core.Entities.IO
{
    using System;
    using System.IO;
    using System.Web;
    using Core.Exceptions;
    using Interfaces;

    public enum ReferenceTypeEnum : byte
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

        public FileSystem(string oldName, Stream stream = default(Stream), bool isTemp = false)
        {
            Id = Guid.Empty;
            OldName = oldName;
            Extension = oldName.Substring(oldName.LastIndexOf('.'));

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
        /// 全名
        /// </summary>
        public string FullName => Path + Name;

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
        public bool IsTemp { get; set; }

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
        public ReferenceTypeEnum? ReferenceType { get; set; }

        /// <summary>
        /// 虚拟路径转物理路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>物理路径</returns>
        public static string PhysicalPath(string virtualPath)
        {
            var physicalPath = HttpContext.Current.Server.MapPath(virtualPath);

            return physicalPath;
        }

        public void CreatePath()
        {
            if (Stream == default(MemoryStream))
            {
                throw new ArgumentNullException(nameof(Stream), "流为null");
            }

            // 文件所属文件夹路径（虚拟路径）
            Path = IsTemp ? VirtualPath + @"Temps\\" : VirtualPath + DateTime.Now.ToString("yyyyMM") + "\\";

            // 创建文件夹
            Directory.CreateDirectory(PhysicalPath(Path));
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if (Stream == default(MemoryStream) || Stream.Length == 0)
            {
                throw new ArgumentNullException(nameof(Stream), "流为null");
            }

            var physicalPath = PhysicalPath(Path);

            if (Directory.Exists(physicalPath) == false)
            {
                throw new ArgumentAppException(message: "文件夹不存在");
            }

            // 在文件夹下创建新文件，返回文件流
            var fs = File.Create(physicalPath + Name);

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
                var bytes = File.ReadAllBytes(PhysicalPath(FullName));

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
