namespace Data.Repositories
{
    using System;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories.LoanRepositories;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(MyContext context) : base(context)
        {
        }

        public override Guid Create(Organization entity)
        {
            if (Guid.Empty.Equals(entity.Id))
            {
                entity.Id = Guid.NewGuid();
            }

            return base.Create(entity);
        }
    }
}
