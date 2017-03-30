namespace Core.Interfaces.Repositories.ProcessRepositories
{
    using Core.Entities.Finance.Partners;
    using Entities;

    public interface IPartnerRepository : IRepository<Partner>
    {
        Partner GetByUser(AppUser user);
    }
}
