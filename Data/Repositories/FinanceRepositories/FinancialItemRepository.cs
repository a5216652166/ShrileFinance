namespace Data.Repositories.FinanceRepositories
{
    using Core.Entities.Finance.Financial;
    using Core.Interfaces.Repositories.FinanceRepositories.FinanceRepositories;

    public class FinancialItemRepository : BaseRepository<FinanceItem>, IFinancialItemRepository
    {
        public FinancialItemRepository(MyContext context) : base(context)
        {
        }
    }
}
