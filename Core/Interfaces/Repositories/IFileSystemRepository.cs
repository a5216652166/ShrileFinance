namespace Core.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.IO;

    public interface IFileEncapsulationRepository : IRepository<FileSystem>
    {
        IQueryable<FileSystem> GetByIds(ICollection<Guid> ids);
    }
}
