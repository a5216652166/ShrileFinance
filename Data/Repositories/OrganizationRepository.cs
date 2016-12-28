namespace Data.Repositories
{
    using System.Data;
    using System.Data.SqlClient;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(MyContext context) : base(context)
        {
        }
    }
}
