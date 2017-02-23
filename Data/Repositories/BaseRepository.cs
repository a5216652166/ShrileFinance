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

        public virtual TEntity Get(Guid key)
        {
            if (key == Guid.Empty)
            {
                return default(TEntity);
            }

            return Entities?.FindAsync(key).Result;
        }

        public virtual IQueryable<TEntity> GetAll() =>
            Filter(Entities);

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) =>
            Filter(Entities.Where(predicate));

        public virtual IPagedList<TEntity> PagedList(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize) =>
            GetAll(predicate).OrderByDescending(m => m.Id).ToPagedList(pageNumber, pageSize);

        public virtual Guid Create(TEntity entity) =>
            Entities.Add(entity).Id;

        public virtual void Remove(TEntity entity) =>
            Context.Entry(entity).State = EntityState.Deleted;

        public virtual int Commit()
        {
            var errorEntitys = Context.GetValidationErrors().Where(m => m.IsValid == false);

            if (errorEntitys.Count() == 0)
            {
                return Context.SaveChanges();
            }
            else
            {
                var errorBuild = new System.Text.StringBuilder();

                foreach (var errorEntity in errorEntitys)
                {
                    foreach (var error in errorEntity.ValidationErrors)
                    {
                        errorBuild.Append(error.PropertyName + "\t" + error.ErrorMessage + "\r\n");
                    }
                }

                throw new ArgumentOutOfRangeException(errorBuild.ToString());
            }
        }

        private IQueryable<TEntity> Filter(IQueryable<TEntity> entities)
        {
            var entitieList = new List<TEntity>();

            if (entities != null && entities.Count() == 0)
            {
                // 如果实现了IProcessable接口，且Hidden属性值为true，则过滤该条数据
                foreach (var item in entities)
                {
                    entitieList.Add(item);

                    if (item is IProcessable && ((IProcessable)item).Hidden == HiddenEnum.审核中)
                    {
                        entitieList.Remove(item);
                    }
                }
            }

            return entitieList.AsQueryable();
        }
    }
}
