namespace Data.Repositories
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Entities.Partner;
    using Core.Interfaces.Repositories;

    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(MyContext context) : base(context)
        {
        }

        public Partner GetByUser(AppUser user)
        {
            var query = Context.Database.SqlQuery<Guid>("SELECT PartnerId FROM CRET_PartnerAccount WHERE AccountId = @p0", user.Id);

            var partnerId = query.Single();

            return Get(partnerId);
        }
    }
}
