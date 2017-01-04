namespace Data.Repositories
{
    using System.Linq;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public LoanRepository(MyContext context) : base(context)
        {
        }

        public IPagedList<Loan> PagedList(string searchString, int page, int size, LoanStatusEnum? status)
        {
            var loans = GetAll();

            // 借据编号筛选
            if (!string.IsNullOrEmpty(searchString))
            {
                loans = loans.Where(m => m.ContractNumber.Contains(searchString));
            }

            // 状态筛选
            if (status.HasValue)
            {
                loans = loans.Where(m => m.Status == status);
            }

            // 排序
            loans = loans.OrderByDescending(m => m.Id);

            // 分页
            return loans.ToPagedList(page, size);
        }
    }
}
