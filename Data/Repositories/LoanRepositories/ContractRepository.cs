namespace Data.Repositories
{
    using System;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories.LoanRepositories;

    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(MyContext context) : base(context)
        {
        }

        public override Guid Create(Contract entity)
        {
            if (Guid.Empty.Equals(entity.Id))
            {
                entity.Id = Guid.NewGuid();
            }

            return base.Create(entity);
        }
    }
}
