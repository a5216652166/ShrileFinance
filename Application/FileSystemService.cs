namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Core.Entities.IO;
    using Core.Interfaces.Repositories;
    using Infrastructure.File;

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
        /// <param name="isTemp">临时文件</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(FileInfo fileInfo, bool isTemp = false)
        {
            if (fileInfo == null)
            {
                throw new ArgumentNullException("创建文件使用的参数为null");
            }

            var ms = new MemoryStream();
            using (var fs = fileInfo.OpenRead())
            {
                fs.CopyTo(ms);

                fs.Flush();
            }

            return ConvertToFileSystem(ms, fileInfo.Name, fileInfo.Extension, isTemp: isTemp);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="isTemp">临时文件</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(string path, bool isTemp = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("创建文件使用的参数为null");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("创建文件使用的路径有误");
            }

            var fileInfo = new FileInfo(path);
            var ms = new MemoryStream();
            using (var fs = fileInfo.OpenRead())
            {
                fs.CopyTo(ms);

                fs.Flush();
            }

            return ConvertToFileSystem(ms, fileInfo.Name, fileInfo.Extension, isTemp: isTemp);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="name">文件名</param>
        /// <param name="extension">扩展名</param>
        /// <param name="isTemp">临时文件</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(Stream stream, string name, string extension, bool isTemp = false)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("创建文件使用的参数为null");
            }

            return ConvertToFileSystem(stream, name, extension, isTemp: isTemp);
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="name">文件名</param>
        /// <param name="extension">扩展名</param>
        /// <param name="isTemp">临时文件</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(byte[] buffer, string name, string extension, bool isTemp = false)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("创建文件使用的参数为null");
            }

            return new FileSystem(name, extension, stream: new MemoryStream(buffer), isTemp: isTemp);
        }

        /// <summary>
        /// 文件打包
        /// </summary>
        /// <param name="fileInfos">文件集合</param>
        /// <returns>打包后的内存流</returns>
        public MemoryStream Compression(IEnumerable<FileSystem> fileInfos)
        {
            if (fileInfos == null)
            {
                return null;
            }

            var dictonary = new Dictionary<string, byte[]>();

            foreach (var item in fileInfos)
            {
                var ms = new MemoryStream();
                item.Stream.CopyTo(ms);

                dictonary.Add(item.Name, ms.ToArray());
            }

            if (dictonary.Count == 1)
            {
                return new MemoryStream(dictonary.First().Value);
            }

            return FileHelper.Compression(dictonary);
        }

        private FileSystem ConvertToFileSystem(Stream stream, string name, string extension, bool isTemp = false)
        {
            var ms = new MemoryStream();
            stream.CopyTo(ms);

            return new FileSystem(name, extension, stream: ms, isTemp: isTemp);
        }
    }
}
