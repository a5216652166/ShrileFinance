namespace Core.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Entities;
    using X.PagedList;

    public interface IRepository<TEntity> : IUnitOfWork
        where TEntity : Entity, IAggregateRoot
    {
        TEntity Get(Guid key);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        IPagedList<TEntity> PagedList(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);

        Guid Create(TEntity entity);

        void Modify(TEntity entity);

        void Remove(TEntity entity);

        TEntity RemoveOldEntity(Guid id);
    }
}
