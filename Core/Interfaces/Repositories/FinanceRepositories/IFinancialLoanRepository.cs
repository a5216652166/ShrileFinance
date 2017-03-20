namespace Core.Interfaces.Repositories.FinanceRepositories
{
    using System;
    using Core.Entities.Finance.Financial;
    using X.PagedList;

    public interface IFinancialLoanRepository : IRepository<FinancialLoan>
    {
        IPagedList<FinancialLoan> FinancialLoanList(string searchString, int page, int size, DateTime? beginTime = null, DateTime? endTime = null);
    }
}
