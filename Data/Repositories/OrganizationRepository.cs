namespace Data.Repositories
{
    using System;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository,IProcessable
    {
        public OrganizationRepository(MyContext context) : base(context)
        {
        }

        public virtual bool Hidden { get; set; }
    }
}
