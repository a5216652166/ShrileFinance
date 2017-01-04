namespace Data.Repositories
{
    using Core.Entities.Loan;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;

    public class CreditContractRepository : BaseRepository<CreditContract>, ICreditContractRepository, IProcessable
    {
        public CreditContractRepository(MyContext context) : base(context)
        {
        }

        public virtual bool Hidden { get; set; }
    }
}
