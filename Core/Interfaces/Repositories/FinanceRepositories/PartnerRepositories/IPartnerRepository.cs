﻿namespace Core.Interfaces.Repositories.FinanceRepositories.PartnerRepositories
{
    using System;
    using Core.Entities.Finance.Partners;
    using X.PagedList;

    public interface IPartnerRepository: IRepository<Partner>
    {
        IPagedList<Partner> FinancialLoanList(string searchString, int page, int size, DateTime? beginTime = null, DateTime? endTime = null);
    }
}
