namespace Data.Repositories
{
    using System.Linq;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class ProduceRepository : BaseRepository<Produce>, IProduceRepository
    {
        public ProduceRepository(MyContext context) : base(context)
        {
        }

        public IPagedList<Produce> List(string searchString, int page, int size)
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
