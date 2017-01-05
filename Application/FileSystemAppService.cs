namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using Core.Entities.IO;
    using Core.Interfaces.Repositories;
    using Infrastructure.File;

    public class FileSystemAppService
    {
        private readonly IFileSystemRepository repository;

        public FileSystemAppService(IFileSystemRepository repository)
        {
            this.repository = repository;
        }

        public List<FileSystem> GetAll()
        {
            return ImportStream(repository.GetAll());
        }

        public List<FileSystem> GetByIds(ICollection<Guid> id)
        {
            return ImportStream(repository.GetByIds(id));
        }

        public FileSystem Get(Guid id)
        {
            return ImportStream(new List<FileSystem>() { repository.Get(id) }).First();
        }

        public void Delete(IEnumerable<FileSystem> fileSystems)
        {
            foreach (var item in fileSystems)
            {
                repository.Remove(item);
            }

            repository.Commit();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="postedFile">文件信息</param>
        /// <param name="isTemp">临时文件</param>
        /// <returns>文件</returns>
        public FileSystem CreatFile(HttpPostedFile postedFile, bool isTemp = false)
        {
            if (postedFile == null)
            {
                throw new ArgumentNullException("postedFile", "创建文件使用的参数为null");
            }

            var ms = postedFile.InputStream;
            var name = postedFile.FileName;

            return ConvertToFileSystem(ms, name.Substring(0, name.LastIndexOf('.')), name.Substring(name.LastIndexOf('.')), isTemp: isTemp);
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
                throw new ArgumentNullException("fileInfo", "创建文件使用的参数为null");
            }

            var ms = GetStreamFormFs(fileInfo);

            return ConvertToFileSystem(ms, fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')), fileInfo.Extension, isTemp: isTemp);
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
                throw new ArgumentNullException(paramName: $"{path}", message: "路径错误");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(message: $"{path}文件不存在");
            }

            var fileInfo = new FileInfo(path);
            var ms = GetStreamFormFs(fileInfo);

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
                throw new ArgumentNullException("stream", "流为null");
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
                throw new ArgumentNullException("buffer", "buffer为null");
            }

            return ConvertToFileSystem(new MemoryStream(buffer), name, extension, isTemp: isTemp);
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
            var fileSystem = new FileSystem(name, extension, stream: stream, isTemp: isTemp);

            fileSystem.Save();
            repository.Create(fileSystem);
            repository.Commit();

            return fileSystem;
        }

        private List<FileSystem> ImportStream(IEnumerable<FileSystem> fileInfos)
        {
            foreach (var item in fileInfos)
            {
                if (!string.IsNullOrEmpty(item.Path))
                {
                    var path = HttpContext.Current.Server.MapPath(item.Path);

                    if (File.Exists(path))
                    {
                        var fs = File.OpenRead(path);
                        item.Stream = new MemoryStream();

                        fs.CopyTo(item.Stream);
                        fs.Dispose();
                    }
                }
            }

            return fileInfos.ToList();
        }

        private MemoryStream GetStreamFormFs(FileInfo fileInfo)
        {
            MemoryStream ms = null;

            if (fileInfo != null)
            {
                var fs = fileInfo.OpenRead();
                ms = new MemoryStream();

                fs.CopyTo(ms);
                fs.Dispose();
            }

            return ms;
        }
    }
}
