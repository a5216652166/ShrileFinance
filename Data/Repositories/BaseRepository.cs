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
        protected BaseRepository(MyContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        protected DbContext Context { get; private set; }

        protected DbSet<TEntity> Entities { get; private set; }

        public virtual IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = Entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public virtual TEntity Get(Guid key)
        {
            return Entities.Find(key);
        }

        public virtual Guid Create(TEntity entity)
        {
            Entities.Add(entity);

            return entity.Id;
        }

        public virtual void Modify(TEntity entity)
        {
            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Deleted)
            {
                Entities.Attach(entity);
            }

            Entities.Remove(entity);
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
