namespace Core.Interfaces.Repositories.LoanRepositories
{
    using System;
    using System.Linq.Expressions;
    using Entities.Customers.Enterprise;
    using X.PagedList;

    /// <summary>
    /// 仓储
    /// </summary>
    public interface IOrganizationRepository : IRepository<Organization>
    {
        IPagedList<Organization> PagedList(Expression<Func<Organization, bool>> predicate, int pageNumber, int pageSize);
    }
}
