namespace Core.Interfaces.Repositories
{
    using System;
    using Entities.Produce;
    using X.PagedList;

    /// <summary>
    /// 产品仓储
    /// </summary>
    public interface IProduceRepository : IRepository<Produce>
    {
        IPagedList<Produce> List(string searchString, int page, int size);
    }
}
