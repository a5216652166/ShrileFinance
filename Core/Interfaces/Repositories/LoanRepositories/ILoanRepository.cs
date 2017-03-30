namespace Core.Interfaces.Repositories.LoanRepositories
{
    using Entities.Loan;
    using X.PagedList;

    public interface ILoanRepository : IRepository<Loan>
    {
        IPagedList<Loan> PagedList(string searchString, int page, int size, LoanStatusEnum? status);
    }
}
