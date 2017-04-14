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

        /// <summary>
        /// 通过引用标识和表单名获取文件
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="tableName">表单名</param>
        /// <returns></returns>
        public List<FileSystem> GetAll(Guid referenceId, TableNameEnum tableName, IEnumerable<Guid?> referencedSids = null)
        {
            referencedSids = referencedSids ?? new List<Guid?>();

            referencedSids = referencedSids.Where(m => m.HasValue);

            var list = fileSystemRepository.GetAll(m => tableName == m.ReferenceType && m.ReferenceId == referenceId && referencedSids.Contains(m.ReferenceSid));

            return list.ToList();
        }

        /// <summary>
        /// 通过引用标识和表单名删除文件
        /// </summary>
        /// <param name="referenceId">引用标识</param>
        /// <param name="tableName">表单名</param>
        /// <param name="rsids">分组标识</param>
        /// <returns></returns>
        public int DeleteAll(Guid referenceId, TableNameEnum tableName, IEnumerable<Guid?> rsids = default(IEnumerable<Guid?>))
        {
            rsids = rsids == default(IEnumerable<Guid?>) ? new List<Guid?>() : rsids.Where(m => m.HasValue);

            var list = fileSystemRepository.GetAll(m => tableName == m.ReferenceType && m.ReferenceId == referenceId && rsids.Contains(m.ReferenceSid));

            foreach (var item in list)
            {
                fileSystemRepository.Remove(item);
            }

            return fileSystemRepository.Commit();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="postedFiles">文件信息</param>
        /// <param name="rId">引用标识</param>
        /// <param name="rsid">分组标识</param>
        /// <param name="tableName">表单名</param>
        /// <param name="isTemp">临时文件</param>
        /// <returns></returns>
        public List<FileSystem> CreatFile(HttpFileCollection postedFiles, Guid rId, Guid rsid, TableNameEnum tableName, bool isTemp = false)
        {
            if (postedFiles == null)
            {
                throw new ArgumentNullException(nameof(postedFiles), "创建文件使用的参数为null");
            }

            var fileSystems = new List<FileSystem>();

            for (int i = 0; i < postedFiles.Count; i++)
            {
                var name = postedFiles[i].FileName;

                var fileSystem = ConvertToFileSystem(postedFiles[i], name.Substring(0, name.LastIndexOf('.')), name.Substring(name.LastIndexOf('.')), isTemp: isTemp);

                fileSystem.ReferenceId = rId;
                fileSystem.ReferenceSid = rsid;
                fileSystem.ReferenceType = tableName;

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

            var fileSystem = ConvertToFileSystem(fileInfo, fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')), fileInfo.Extension, isTemp: isTemp);

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

            var fileSystem = ConvertToFileSystem(path, fileInfo.Name, fileInfo.Extension, isTemp: isTemp);

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
        public FileSystem CreatFile(Stream stream, string name, string extension, bool isTemp = false)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream), "流为null");
            }

            var fileSystem = ConvertToFileSystem(stream, name, extension, isTemp: isTemp);

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
        public FileSystem CreatFile(byte[] buffer, string name, string extension, bool isTemp = false)
        {
            if (buffer == default(byte[]))
            {
                throw new ArgumentNullException(nameof(buffer), "buffer为null");
            }

            var fileSystem = ConvertToFileSystem(buffer, name, extension, isTemp: isTemp);

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
                if (dictonary.Keys.Contains(item.OldName) == false)
                {
                    var ms = new MemoryStream();
                    item.Stream.CopyTo(ms);

                    dictonary.Add(item.OldName, ms.ToArray());
                }
            }

            return FileHelper.Compression(dictonary);
        }

        private FileSystem ConvertToFileSystem<T>(T value, string name, string extension, bool isTemp = false)
        {
            var stream = default(Stream);

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

            if (stream == default(Stream))
            {
                throw new ArgumentNullException(nameof(stream), "不支持的类型:" + value.GetType().FullName);
            }

            var fileSystem = new FileSystem(name, extension, stream: stream, isTemp: isTemp);

            return fileSystem;
        }

        private void SaveFileSystem(IEnumerable<FileSystem> fileSystems)
        {
            foreach (var item in fileSystems)
            {
                item.Save();

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
                        fs.Flush();
                        fs.Dispose();
                    }
                }
            }

            return fileInfos?.ToList();
        }

        private MemoryStream GetStreamFormFs(FileInfo fileInfo)
        {
            var ms = default(MemoryStream);

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
