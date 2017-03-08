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

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns>文件列表</returns>
        public List<FileSystem> GetAll() => ImportStream(repository.GetAll());

        /// <summary>
        /// 通过标识集合获取
        /// </summary>
        /// <param name="id">标识集合</param>
        /// <returns>文件列表</returns>
        public List<FileSystem> GetByIds(ICollection<Guid> id) => ImportStream(repository.GetByIds(id));

        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>文件</returns>
        public FileSystem Get(Guid id) => ImportStream(
            new List<FileSystem>()
            {
                repository.Get(id)
            })?.First();

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fileSystemIds">标识集合</param>
        /// <returns>删除数目</returns>
        public int Delete(IEnumerable<Guid> fileSystemIds)
        {
            var fileSystems = repository.GetByIds(fileSystemIds.ToList());

            foreach (var item in fileSystems)
            {
                repository.Remove(item);
            }

            return repository.Commit();
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
                throw new ArgumentNullException(nameof(postedFile), "创建文件使用的参数为null");
            }

            var name = postedFile.FileName;

            var fileSystem = ConvertToFileSystem(postedFile, name.Substring(0, name.LastIndexOf('.')), name.Substring(name.LastIndexOf('.')), isTemp: isTemp);

            SaveFileSystem(fileSystem);

            return fileSystem;
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
                throw new ArgumentNullException(nameof(fileInfo), "创建文件使用的参数为null");
            }

            var fileSystem = ConvertToFileSystem(fileInfo, fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')), fileInfo.Extension, isTemp: isTemp);

            SaveFileSystem(fileSystem);

            return fileSystem;
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
                throw new ArgumentNullException(nameof(path), "空路径");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"{path}文件不存在");
            }

            var fileInfo = new FileInfo(path);

            var fileSystem = ConvertToFileSystem(path, fileInfo.Name, fileInfo.Extension, isTemp: isTemp);

            SaveFileSystem(fileSystem);

            return fileSystem;
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
                throw new ArgumentNullException(nameof(stream), "流为null");
            }

            var fileSystem = ConvertToFileSystem(stream, name, extension, isTemp: isTemp);

            SaveFileSystem(fileSystem);

            return fileSystem;
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
                throw new ArgumentNullException(nameof(buffer), "buffer为null");
            }

            var fileSystem = ConvertToFileSystem(buffer, name, extension, isTemp: isTemp);

            SaveFileSystem(fileSystem);

            return fileSystem;
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

        private FileSystem ConvertToFileSystem<T>(T value, string name, string extension, bool isTemp = false)
        {
            Stream stream = null;

            if (value is HttpPostedFile)
            {
                stream = (value as HttpPostedFile).InputStream;
            }
            else if (value is FileInfo)
            {
                stream = GetStreamFormFs(value as FileInfo);
            }
            else if (value is string)
            {
                stream = GetStreamFormFs(new FileInfo(value as string));
            }
            else if (value is Stream)
            {
                stream = value as Stream;
            }
            else if (value is byte[])
            {
                stream = new MemoryStream(value as byte[]);
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "不支持的类型:" + value.GetType().FullName);
            }

            var fileSystem = new FileSystem(name, extension, stream: stream, isTemp: isTemp);

            return fileSystem;
        }

        private void SaveFileSystem(FileSystem fileSystem)
        {
            if (fileSystem.Id == Guid.Empty)
            {
                repository.Create(fileSystem);
            }
            else
            {
                repository.Modify(fileSystem);
            }

            repository.Commit();
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

            return fileInfos?.ToList();
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
