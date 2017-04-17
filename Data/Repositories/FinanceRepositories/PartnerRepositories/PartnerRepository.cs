namespace Data.Repositories
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Entities.Finance.Partners;
    using Core.Interfaces.Repositories.ProcessRepositories;

    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(MyContext context) : base(context)
        {
        }

        public Partner GetByUser(AppUser user)
        {
            var query = Context.Database.SqlQuery<Guid>("SELECT PartnerId FROM CRET_PartnerAccount WHERE AccountId = @p0", user.Id);

            var partnerId = default(Guid);

            try
            {
                partnerId = query.Single();
            }
            catch (InvalidOperationException ex)
            {
                throw new Core.Exceptions.InvalidOperationAppException(message: "无法找到当前用户的所属合作商。", innerException: ex);
            }

            return Get(partnerId);
        }
    }
}
