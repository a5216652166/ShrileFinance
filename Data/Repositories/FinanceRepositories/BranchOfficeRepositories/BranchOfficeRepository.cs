namespace Data.Repositories.FinanceRepositories.BranchOfficeRepositories
{
    using System.Linq;
    using Core.Entities.Finance.BranchOffices;
    using Core.Interfaces.Repositories.FinanceRepositories.BranchOfficeRepositories;
    using X.PagedList;

    public class BranchOfficeRepository : BaseRepository<BranchOffice>, IBranchOfficeRepository
    {
        public BranchOfficeRepository(MyContext context) : base(context)
        {
        }

        IPagedList<BranchOffice> IBranchOfficeRepository.PageList(string searchString, int page, int size)
        {
            var query = GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Name.Contains(searchString));
            }

            return query.ToPagedList(page, size);
        }
    }
}
