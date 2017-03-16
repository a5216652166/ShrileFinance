namespace Data.Repositories.FinanceRepositories
{
    using System;
    using System.Linq;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using X.PagedList;

    public class NewProduceRepository : BaseRepository<NewProduce>, INewProduceRepository
    {
        public NewProduceRepository(MyContext context) : base(context)
        {
        }

        IPagedList<NewProduce> INewProduceRepository.ProduceList(string searchString, int page, int size, DateTime? beginTime, DateTime? endTime)
        {
            var products = default(IQueryable<NewProduce>);

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
