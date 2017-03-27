namespace Core.Interfaces.Repositories.FinanceRepositories.PartnerRepositories
{
    using System;
    using Core.Entities.Finance.Partners;
    using X.PagedList;

    public interface IPartnerUserRepository : IRepository<PartnerUser>
    {
        IPagedList<PartnerUser> PartnerUserList(string searchString, int page, int size, DateTime? beginTime = null, DateTime? endTime = null);
    }
}
