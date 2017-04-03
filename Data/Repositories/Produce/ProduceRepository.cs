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

        public IPagedList<Produce> List(string searchString, int page, int size)
        {
            var entities = GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                entities.Where(m => m.Code.Contains(searchString));
            }

            return entities.ToPagedList(page, size);
        }
    }
}
