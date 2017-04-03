namespace Core.Produce
{
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public interface IProduceRepository : IRepository<Produce>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchString">代码</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <returns></returns>
        IPagedList<Produce> List(string searchString, int page, int size);
    }
}
