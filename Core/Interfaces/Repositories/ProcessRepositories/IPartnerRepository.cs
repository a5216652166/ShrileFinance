namespace Core.Interfaces.Repositories
{
    using Entities;
    using Entities.Partner;

    public interface IPartnerRepository : IRepository<Partner>
    {
        Partner GetByUser(AppUser user);
    }
}
