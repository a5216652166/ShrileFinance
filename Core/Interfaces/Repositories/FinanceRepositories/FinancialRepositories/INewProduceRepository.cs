namespace Core.Interfaces.Repositories.FinanceRepositories.FinancialRepositories
{
    using System;
    using Entities.Finance.Financial;
    using X.PagedList;

    public interface INewProduceRepository : IRepository<Produce>
    {
        IPagedList<Produce> ProduceList(string searchString, int page, int size, DateTime? beginTime = null, DateTime? endTime = null);
    }
}
