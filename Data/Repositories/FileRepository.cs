﻿namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities.IO;
    using Core.Interfaces.Repositories;

    public class FileRepository : BaseRepository<FileSystem>, IFileSystemRepository
    {
        public FileRepository(MyContext context) : base(context)
        {
        }

        IQueryable<FileSystem> IFileSystemRepository.GetByIds(ICollection<Guid> ids)
        {
            return GetAll(m => ids.Contains(m.Id));
        }
    }
}
