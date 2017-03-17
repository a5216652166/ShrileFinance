namespace Data.Repositories.FinanceRepositories
{
    using System;
    using System.Linq;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories.FinanceRepositories;
    using X.PagedList;

    public class FinancialLoanRepository : BaseRepository<FinancialLoan>, IFinancialLoanRepository
    {
        public FinancialLoanRepository(MyContext context) : base(context)
        {
        }

        IPagedList<FinancialLoan> IFinancialLoanRepository.FinancialLoanList(string searchString, int page, int size, DateTime? beginTime, DateTime? endTime)
        {
            var products = default(IQueryable<FinancialLoan>);

            searchString = searchString ?? string.Empty;

            products = GetAll(item => item.FinancialItem.Name.Contains(searchString)).OrderByDescending(m => m.CreatedDate);

            if (beginTime != null)
            {
                products = products.Where(item => item.LoanDate >= beginTime.Value);
            }

            if (endTime != null)
            {
                products = products.Where(item => item.LoanDate < endTime.Value.AddDays(1));
            }

            return products?.ToPagedList(page, size);
        }
    }
}
