namespace Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
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

        protected DbContext Context
        {
            get { return context; }
        }

        private DbSet<TEntity> Entities
        {
            get { return context.Set<TEntity>(); }
        }

        public virtual TEntity Get(Guid key)
        {
            return Entities.Find(key);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
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
            return Context.SaveChanges();
        }
    }
}
