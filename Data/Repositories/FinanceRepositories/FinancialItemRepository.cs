namespace Data.Repositories.FinanceRepositories
{
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories.FinanceRepositories;

    public class FinancialItemRepository : BaseRepository<FinancialItem>, IFinancialItemRepository
    {
        public FinancialItemRepository(MyContext context) : base(context)
        {
        }
    }
}
