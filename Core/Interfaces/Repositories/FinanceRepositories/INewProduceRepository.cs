namespace Core.Interfaces.Repositories.FinanceRepositories
{
    using System;
    using Entities.Finance.Financial;
    using X.PagedList;

    public interface INewProduceRepository : IRepository<NewProduce>
    {
        IPagedList<NewProduce> ProduceList(string searchString, int page, int size, DateTime? beginTime = null, DateTime? endTime = null);
    }
}
