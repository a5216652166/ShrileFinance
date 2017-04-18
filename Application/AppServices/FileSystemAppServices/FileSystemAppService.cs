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
        private readonly IFileSystemRepository fileSystemRepository;

        public FileSystemAppService(IFileSystemRepository fileSystemRepository)
        {
            this.fileSystemRepository = fileSystemRepository;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns>文件列表</returns>
        public List<FileSystem> GetAll()
        {
            var list = fileSystemRepository.GetAll();

            return ImportStream(list);
        }

        /// <summary>
        /// 通过标识集合获取
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <returns>文件列表</returns>
        public List<FileSystem> GetAllByIds(IEnumerable<Guid> ids)
        {
            var list = fileSystemRepository.GetAll(m => ids.Contains(m.Id));

            return ImportStream(list);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <returns>删除数目</returns>
        public int Delete(IEnumerable<Guid> ids)
        {
            var fileSystems = fileSystemRepository.GetAll(m => ids.Contains(m.Id));

            foreach (var item in fileSystems)
            {
                fileSystemRepository.Remove(item);
            }

            return fileSystemRepository.Commit();
        }

        public List<FileSystem> GetAll(Guid referenceId, ReferenceTypeEnum referenceType, IEnumerable<Guid?> ids)
        {
            ids = ids == default(IEnumerable<Guid?>) ? new List<Guid?>() : ids.Where(m => m.HasValue);

            var list = fileSystemRepository.GetAll(m => m.ReferenceId==referenceId && referenceType == m.ReferenceType && ids.Contains(m.Id));

            return list.ToList();
        }

        /// <summary>
        /// 通过引用标识和表单名获取文件
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="referenceType">表单名</param>
        /// <param name="referenceSid">分组</param>
        /// <returns></returns>
        public List<FileSystem> GetAll(Guid referenceId, ReferenceTypeEnum referenceType, Guid? referenceSid = default(Guid?))
        {
            var list = fileSystemRepository.GetAll(m => referenceType == m.ReferenceType && m.ReferenceId == referenceId);

            if (referenceSid.HasValue)
            {
                list = list.Where(m => m.ReferenceSid == referenceSid.Value);
            }

            return list.ToList();
        }

        /// <summary>
        /// 通过引用标识和表单名删除文件
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="referenceType">表单名</param>
        /// <param name="ids">分组标识</param>
        /// <returns></returns>
        public int DeleteAll(Guid referenceId, ReferenceTypeEnum referenceType, IEnumerable<Guid?> ids = default(IEnumerable<Guid?>))
        {
            ids = ids == default(IEnumerable<Guid?>) ? new List<Guid?>() : ids.Where(m => m.HasValue);

            var list = fileSystemRepository.GetAll(m => referenceType == m.ReferenceType && m.ReferenceId == referenceId && ids.Contains(m.Id));

            foreach (var item in list)
            {
                fileSystemRepository.Remove(item);

                // 删除磁盘文件
                var file = FileSystem.PhysicalPath(item.FullName);
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

            return fileSystemRepository.Commit();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="postedFiles">文件信息</param>
        /// <param name="referenceId">引用标识</param>
        /// <param name="referenceSid">分组标识</param>
        /// <param name="referenceType">表单名</param>
        /// <param name="isTemp">临时文件</param>
        /// <returns></returns>
        public List<FileSystem> CreatFile(HttpFileCollection postedFiles, Guid referenceId, Guid referenceSid, ReferenceTypeEnum? referenceType, bool isTemp = false)
        {
            if (postedFiles == default(HttpFileCollection) || referenceType.HasValue == false)
            {
                throw new ArgumentNullException(nameof(postedFiles), "创建文件使用的参数为null");
            }

            var fileSystems = new List<FileSystem>();

            for (int i = 0; i < postedFiles.Count; i++)
            {
                var name = postedFiles[i].FileName;

                CheckFileName(referenceId, referenceSid, referenceType, name);

                var fileSystem = ConvertToFileSystem(postedFiles[i], name, isTemp: isTemp);

                fileSystem.ReferenceId = referenceId;
                fileSystem.ReferenceSid = referenceSid;
                fileSystem.ReferenceType = referenceType;

                fileSystems.Add(fileSystem);
            }

            SaveFileSystem(fileSystems);

            return fileSystems;
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

            var fileSystem = ConvertToFileSystem(fileInfo, fileInfo.Name, isTemp: isTemp);

            SaveFileSystem(new FileSystem[] { fileSystem });

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

            var fileSystem = ConvertToFileSystem(path, fileInfo.Name, isTemp: isTemp);

            SaveFileSystem(new FileSystem[] { fileSystem });

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
        public FileSystem CreatFile(Stream stream, string name, bool isTemp = false)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "流为null");
            }

            var fileSystem = ConvertToFileSystem(stream, name, isTemp: isTemp);

            SaveFileSystem(new FileSystem[] { fileSystem });

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
        public FileSystem CreatFile(byte[] buffer, string name, bool isTemp = false)
        {
            if (buffer == default(byte[]))
            {
                throw new ArgumentNullException(nameof(buffer), "buffer为null");
            }

            var fileSystem = ConvertToFileSystem(buffer, name, isTemp: isTemp);

            SaveFileSystem(new FileSystem[] { fileSystem });

            return fileSystem;
        }

        /// <summary>
        /// 文件打包
        /// </summary>
        /// <param name="fileInfos">文件集合</param>
        /// <returns>打包后的内存流</returns>
        public MemoryStream Compression(IEnumerable<FileSystem> fileInfos)
        {
            if (fileInfos == default(IEnumerable<FileSystem>))
            {
                return default(MemoryStream);
            }

            var dictonary = new Dictionary<string, byte[]>();

            foreach (var item in fileInfos)
            {
                if (dictonary.Keys.Contains(item.OldName + item.Extension) == false)
                {
                    var ms = item.Read();

                    dictonary.Add(item.OldName + item.Extension, ms.ToArray());
                }
            }

            return FileHelper.Compression(dictonary);
        }

        private FileSystem ConvertToFileSystem<T>(T value, string name, bool isTemp = false)
        {
            var stream = default(Stream);

            if (value is HttpPostedFile)
            {
                stream = (value as HttpPostedFile).InputStream;
            }
            else if (value is FileInfo)
            {
                stream = ParseFileInfo(value as FileInfo);
            }
            else if (value is string)
            {
                stream = ParseFileInfo(new FileInfo(value as string));
            }
            else if (value is Stream)
            {
                stream = value as Stream;
            }
            else if (value is byte[])
            {
                stream = new MemoryStream(value as byte[]);
            }

            if (stream == default(Stream))
            {
                throw new ArgumentNullException(nameof(stream), "不支持的类型:" + value.GetType().FullName);
            }

            var fileSystem = new FileSystem(name, stream: stream, isTemp: isTemp);

            return fileSystem;
        }

        private void SaveFileSystem(IEnumerable<FileSystem> fileSystems)
        {
            foreach (var item in fileSystems)
            {
                item.CreatePath();

                if (item.Id == Guid.Empty)
                {
                    fileSystemRepository.Create(item);
                }
                else
                {
                    fileSystemRepository.Modify(item);
                }
            }

            fileSystemRepository.Commit();

            foreach (var item in fileSystems)
            {
                item.AllowName(item.Id + item.Extension);
                item.AllowPath(FileSystem.VirtualPath + item.Path);

                item.Save();
            }
        }

        private List<FileSystem> ImportStream(IEnumerable<FileSystem> fileInfos)
        {
            foreach (var item in fileInfos)
            {
                if (!string.IsNullOrEmpty(item.FullName))
                {
                    var path = FileSystem.PhysicalPath(item.FullName);

                    if (File.Exists(path))
                    {
                        var fs = File.OpenRead(path);
                        item.Stream = new MemoryStream();

                        fs.CopyTo(item.Stream);
                        fs.Flush();
                        fs.Dispose();
                    }
                }
            }

            return fileInfos?.ToList();
        }

        private MemoryStream ParseFileInfo(FileInfo fileInfo)
        {
            var ms = default(MemoryStream);

            if (fileInfo != default(FileInfo))
            {
                var fs = fileInfo.OpenRead();
                ms = new MemoryStream();

                fs.CopyTo(ms);
                fs.Flush();
                fs.Dispose();
            }

            return ms;
        }

        private void CheckFileName(Guid referenceId, Guid referenceSid, ReferenceTypeEnum? referenceType, string name)
        {
            var files = fileSystemRepository.GetAll(m => m.ReferenceId == referenceId && m.ReferenceSid == referenceSid && m.ReferenceType == referenceType && m.OldName == name);

            if (files.Count() > 0)
            {
                throw new Core.Exceptions.ArgumentAppException(message: $"{name}该文件已存在！");
            }
        }
    }
}
