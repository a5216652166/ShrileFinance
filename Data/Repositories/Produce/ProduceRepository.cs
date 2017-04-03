namespace Data.Repositories.Produce
{
    using System.Linq;
    using Core.Produce;
    using X.PagedList;

    public class ProduceRepository : BaseRepository<Produce>, IProduceRepository
    {
        public ProduceRepository(MyContext context) : base(context)
        {
        }

        public IPagedList<Produce> PagedList(string searchString, int page, int size)
        {
            var query = GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Code.Contains(searchString));
            }

            return query.ToPagedList(page, size);
        }
    }
}
