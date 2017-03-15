namespace Core.Interfaces.Repositories
{
    using Entities.Loan;
    using X.PagedList;

    public interface ILoanRepository : IRepository<Loan>
    {
        IPagedList<Loan> PagedList(string searchString, int page, int size, LoanStatusEnum? status);
    }
}
