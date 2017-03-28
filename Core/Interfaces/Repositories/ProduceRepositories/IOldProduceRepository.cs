namespace Core.Interfaces.Repositories.ProduceRepositories
{
    using Entities.Produce;
    using X.PagedList;

    /// <summary>
    /// 产品仓储
    /// </summary>
    public interface IOldProduceRepository : IRepository<OldProduce>
    {
        IPagedList<OldProduce> List(string searchString, int page, int size);
    }
}
