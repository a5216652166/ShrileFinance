namespace Data.Repositories
{
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories;

    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(MyContext context) : base(context)
        {
        }
    }
}
