namespace Data.Repositories
{
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories.LoanRepositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(MyContext context) : base(context)
        {
        }
    }
}
