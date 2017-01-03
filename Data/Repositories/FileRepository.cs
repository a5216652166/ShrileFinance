namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities.IO;
    using Core.Interfaces.Repositories;

    public class FileRepository : BaseRepository<FileSystem>, IFileEncapsulationRepository
    {
        public FileRepository(MyContext context) : base(context)
        {
        }

        public IQueryable<FileSystem> GetByIds(ICollection<Guid> ids)
        {
            return GetAll(m => ids.Contains(m.Id));
        }
    }
}
