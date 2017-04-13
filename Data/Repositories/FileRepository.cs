namespace Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities.IO;
    using Core.Interfaces.Repositories;

    public class FileSystemRepository : BaseRepository<FileSystem>, IFileSystemRepository
    {
        public FileSystemRepository(MyContext context) : base(context)
        {
        }

        public override FileSystem Get(Guid key)
        {
            var entity = base.Get(key);

            PerfectEntity(entity);

            return entity;
        }

        public override IQueryable<FileSystem> GetAll(Expression<Func<FileSystem, bool>> predicate = null, Func<IQueryable<FileSystem>, IOrderedQueryable<FileSystem>> orderBy = null)
        {
            var entities = base.GetAll(predicate, orderBy);

            foreach (var item in entities)
            {
                PerfectEntity(item);
            }

            return entities;
        }

        public override Guid Create(FileSystem entity)
        {
            entity.DateOfCreate = DateTime.Now;
            entity.AllowPath(entity.Path.Replace(FileSystem.VirtualPath, string.Empty));

            return base.Create(entity);
        }

        public override void Modify(FileSystem entity)
        {
            entity.AllowPath(entity.Path.Replace(FileSystem.VirtualPath, string.Empty));

            base.Modify(entity);
        }

        private void PerfectEntity(FileSystem entity)
        {
            if (string.IsNullOrEmpty(entity.Path))
            {
                return;
            }

            entity.AllowPath(FileSystem.VirtualPath + entity.Path);
            entity.AllowName(entity.Path.Substring(entity.Path.LastIndexOf('\\') + 1));
            entity.Extension = entity.Path.Substring(entity.Path.LastIndexOf('.'));
        }
    }
}
