namespace Data.Repositories
{
    using System;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories.LoanRepositories;

    public class CreditContractRepository : BaseRepository<CreditContract>, ICreditContractRepository
    {
        public CreditContractRepository(MyContext context) : base(context)
        {
        }

        public override Guid Create(CreditContract entity)
        {
            if (Guid.Empty.Equals(entity.Id))
            {
                entity.Id = Guid.NewGuid();
            }

            return base.Create(entity);
        }
    }
}
