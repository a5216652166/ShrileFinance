namespace Core.Interfaces.Repositories.FinanceRepositories.BranchOfficeRepositories
{
    using Core.Entities.Finance.BranchOffices;
    using X.PagedList;

    public interface IBranchOfficeRepository : IRepository<BranchOffice>
    {
        IPagedList<BranchOffice> PageList(string searchString, int page, int size);
    }
}
