namespace Core.Interfaces.Repositories
{
    using Entities;
    using Core.Entities.Finance.Partners;

    public interface IPartnerRepository : IRepository<Partner>
    {
        Partner GetByUser(AppUser user);
    }
}
