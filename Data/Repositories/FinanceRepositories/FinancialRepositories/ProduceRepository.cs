namespace Data.Repositories.FinanceRepositories.FinancialRepositories
{
    using System;
    using System.Linq;
    using Core.Entities.Finance.Financial;
    using Core.Interfaces.Repositories.FinanceRepositories.FinancialRepositories;
    using X.PagedList;

    public class ProduceRepository : BaseRepository<Produce>, IProduceRepository
    {
        public ProduceRepository(MyContext context) : base(context)
        {
        }

        IPagedList<Produce> IProduceRepository.ProduceList(string searchString, int page, int size, DateTime? beginTime, DateTime? endTime)
        {
            var products = default(IQueryable<Produce>);

            searchString = searchString ?? string.Empty;

            products = GetAll(item => item.Code.Contains(searchString)).OrderByDescending(m => m.CreatedDate);

            if (beginTime != null)
            {
                products = products.Where(item => item.CreatedDate >= beginTime.Value);
            }

            if (endTime != null)
            {
                products = products.Where(item => item.CreatedDate < endTime.Value.AddDays(1));
            }

            return products?.ToPagedList(page, size);
        }
    }
}
