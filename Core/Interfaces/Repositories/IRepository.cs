namespace Core.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Entities;

    public interface IRepository<TEntity> : IUnitOfWork
        where TEntity : Entity, IAggregateRoot
    {
        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity Get(Guid key);

        Guid Create(TEntity entity);

        void Modify(TEntity entity);

        void Remove(TEntity entity);
    }
}
