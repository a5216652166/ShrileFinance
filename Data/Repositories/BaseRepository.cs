namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
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

        protected DbContext Context => context;

        private DbSet<TEntity> Entities => context.Set<TEntity>();

        void IRepository<TEntity>.Modify(TEntity entity) =>
           Context.Entry(entity).State = EntityState.Modified;

        public virtual TEntity Get(Guid key) =>
            Entities?.FindAsync(key).Result;

        public virtual IQueryable<TEntity> GetAll() =>
            Filter(Entities);

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) =>
            GetAll().Where(predicate);

        public virtual IPagedList<TEntity> PagedList(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize) =>
            GetAll(predicate).OrderByDescending(m => m.Id).ToPagedList(pageNumber, pageSize);

        public virtual Guid Create(TEntity entity) =>
            Entities.Add(entity).Id;

        public virtual void Remove(TEntity entity) =>
            Context.Entry(entity).State = EntityState.Deleted;

        public virtual int Commit() =>
            Context.SaveChanges();

        private IQueryable<TEntity> Filter(DbSet<TEntity> entities)
        {
            var entitieList = new List<TEntity>();

            if (entities == null || entities.Count() == 0)
            {
                return entitieList.AsQueryable();
            }

            // 如果实现了IProcessable接口，且Hidden属性值为true，则过滤该条数据
            foreach (var item in entities)
            {
                entitieList.Add(item);

                if (item is IProcessable && ((IProcessable)item).Hidden==HiddenEnum.审核中)
                {
                    entitieList.Remove(item);
                }
            }

            return entitieList.AsQueryable();
        }
    }
}
