namespace Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Core.Entities;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        private readonly DbContext context;

        protected BaseRepository(MyContext context)
        {
            this.context = context;
        }

        protected DbContext Context => context;

        private DbSet<TEntity> Entities => context.Set<TEntity>();

        public virtual TEntity Get(Guid key)
        {
            if (Guid.Empty.Equals(key))
            {
                return default(TEntity);
            }

            return Entities.Find(key);
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var entities = Entities.AsQueryable();

            if (predicate != null)
            {
                entities = entities.Where(predicate);
            }

            return entities;
        }

        public virtual IPagedList<TEntity> PagedList(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize)
        {
            return GetAll(predicate).OrderByDescending(m => m.Id).ToPagedList(pageNumber, pageSize);
        }

        public virtual Guid Create(TEntity entity)
        {
            Entities.Add(entity);

            return entity.Id;
        }

        public virtual void Modify(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual int Commit()
        {
            ValidCommit();

            return Context.SaveChanges();
        }

        protected IPagedList<TEntity> ToPagedList(IQueryable<TEntity> superset, int pageNumber, int pageSize)
        {
            return superset.ToPagedList(pageNumber, pageSize);
        }

        private void ValidCommit()
        {
            var errorEntitys = Context.GetValidationErrors().Where(m => m.IsValid == false);

            if (errorEntitys.Count() > 0)
            {
                var errorBuild = new StringBuilder();

                foreach (var errorEntity in errorEntitys)
                {
                    foreach (var error in errorEntity.ValidationErrors)
                    {
                        errorBuild.AppendLine($"{error.PropertyName}\t{error.ErrorMessage}");
                    }
                }

                throw new ArgumentException(errorBuild.ToString());
            }
        }
    }
}
