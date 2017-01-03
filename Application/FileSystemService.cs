namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Infrastructure.File;
    using Core.Entities.IO;
    using Core.Interfaces.Repositories;

    public class FileSystemService
    {
        private readonly IFileEncapsulationRepository repository;

        public FileSystemService(IFileEncapsulationRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(FileInfo fileInfo, bool isTemp = false)
        {
            if (fileInfo == null)
            {
                throw new Exception("创建文件使用的参数为null");
            }

            var ms = new MemoryStream();
            using (var fs = fileInfo.OpenRead())
            {
                fs.CopyTo(ms);

                fs.Flush();
            }

            return new FileSystem(fileInfo.Name, fileInfo.Extension, stream: ms, isTemp: isTemp);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(string path, bool isTemp = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("创建文件使用的参数为null");
            }

            if (File.Exists(path))
            {
                throw new Exception("创建文件使用的路径有误");
            }

            var fileInfo = new FileInfo(path);
            var ms = new MemoryStream();
            using (var fs = fileInfo.OpenRead())
            {
                fs.CopyTo(ms);

                fs.Flush();
            }

            return new FileSystem(fileInfo.Name, fileInfo.Extension, stream: ms, isTemp: isTemp);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="value">流</param>
        /// <param name="name">文件名</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(Stream stream, string name,string extension, bool isTemp = false)
        {
            if (stream == null)
            {
                throw new Exception("创建文件使用的参数为null");
            }

            var ms = new MemoryStream();
            stream.CopyTo(ms);

            return new FileSystem(name, extension, stream: ms, isTemp: isTemp);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="name">文件名</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(byte[] buffer, string name,string extension, bool isTemp = false)
        {
            if (buffer == null)
            {
                throw new Exception("创建文件使用的参数为null");
            }

            return new FileSystem(name, extension, stream: new MemoryStream(buffer), isTemp: isTemp);
        }

        /// <summary>
        /// 文件打包
        /// </summary>
        /// <param name="fileInfos">文件集合</param>
        /// <returns>打包后的内存流</returns>
        public MemoryStream Compression(IEnumerable<FileInfo> fileInfos)
        {
            if (fileInfos == null)
            {
                return null;
            }

            var dictonary = new Dictionary<string, byte[]>();

            foreach (var item in fileInfos)
            {
                using (var fs = item.OpenRead())
                {
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);

                    dictonary.Add(item.Name, ms.ToArray());
                }
            }

            if (dictonary.Count == 1)
            {
                return new MemoryStream(dictonary.First().Value);
            }

            return FileHelper.Compression(dictonary);
        }

        /// <summary>
        /// 文件打包
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>打包后的内存流</returns>
        public MemoryStream Compression(IDictionary<string, byte[]> value)
        {
            if (value == null)
            {
                return null;
            }

            if (value.Count == 1)
            {
                return new MemoryStream(value.First().Value);
            }

            return FileHelper.Compression(value);
        }

        /// <summary>
        /// 文件打包
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>打包后的内存流</returns>
        public MemoryStream Compression(IDictionary<string, Stream> value)
        {
            if (value == null)
            {
                return null;
            }

            if (value.Count == 1)
            {
                var ms = new MemoryStream();
                value.First().Value.CopyTo(ms);

                return ms;
            }

            var dictionary = new Dictionary<string, byte[]>();

            foreach (var item in value)
            {
                var ms = new MemoryStream();
                item.Value.CopyTo(ms);

                dictionary.Add(item.Key, ms.ToArray());
            }

            return FileHelper.Compression(dictionary);
        }
    }
}
