namespace Data.Repositories.FinanceRepositories.PartnerRepositories
{
    using System;
    using System.Linq;
    using Core.Entities.Finance.Partners;
    using Core.Interfaces.Repositories.FinanceRepositories.PartnerRepositories;
    using X.PagedList;

    public class PartnerUserRepository : BaseRepository<NewPartnerUser>, IPartnerUserRepository
    {
        public PartnerUserRepository(MyContext context) : base(context)
        {
        }

        IPagedList<NewPartnerUser> IPartnerUserRepository.PartnerUserList(string searchString, int page, int size, DateTime? beginTime, DateTime? endTime)
        {
            var partners = default(IQueryable<NewPartnerUser>);

            searchString = searchString ?? string.Empty;

            partners = GetAll(item => item.Name.Contains(searchString)).OrderBy(m => m.CreatedDate);

            if (beginTime != null)
            {
                partners = partners.Where(item => item.CreatedDate >= beginTime.Value);
            }

            if (endTime != null)
            {
                partners = partners.Where(item => item.CreatedDate < endTime.Value.AddDays(1));
            }

            return partners?.ToPagedList(page, size);
        }
    }
}
