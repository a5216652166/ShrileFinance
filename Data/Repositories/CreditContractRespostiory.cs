namespace Data.Repositories
{
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;

    public class CreditContractRepository : BaseRepository<CreditContract>, ICreditContractRepository
    {
        public CreditContractRepository(MyContext context) : base(context)
        {
        }
    }
}
