namespace Data.Repositories
{
    using System.Linq;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories.ProduceRepositories;
    using X.PagedList;

    public class OldProduceRepository : BaseRepository<OldProduce>, IOldProduceRepository
    {
        public OldProduceRepository(MyContext context) : base(context)
        {
        }

        public IPagedList<OldProduce> List(string searchString, int page, int size)
        {
            var produces = GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                produces = produces.Where(m => m.Name.Contains(searchString) || m.Code.Contains(searchString));
            }

            produces = produces.OrderByDescending(m => m.Id);

            return produces.ToPagedList(page, size);
        }
    }
}
