namespace Data.Repositories.FinanceRepositories.PartnerRepositories
{
    using Core.Entities.Finance.Partners;
    using Core.Interfaces.Repositories.FinanceRepositories.PartnerRepositories;

    public class PartnerUserRepository : BaseRepository<Core.Entities.Finance.Partners.PartnerUser>, IPartnerUserRepository
    {
        public PartnerUserRepository(MyContext context) : base(context)
        {
        }

        public override void Remove(PartnerUser entity)
        {
        }
    }
}
