namespace Core.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.IO;

    public interface IFileSystemRepository : IRepository<FileSystem>
    {
        IQueryable<FileSystem> GetByIds(IEnumerable<Guid> ids);
    }
}
