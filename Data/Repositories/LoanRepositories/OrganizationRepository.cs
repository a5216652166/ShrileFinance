namespace Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities.Customers.Enterprise;
    using Core.Interfaces.Repositories.LoanRepositories;
    using X.PagedList;

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(MyContext context) : base(context)
        {
        }

        public virtual IPagedList<Organization> PagedList(Expression<Func<Organization, bool>> predicate, int pageNumber, int pageSize)
        {
            return GetAll(predicate).OrderByDescending(m => m.Id).ToPagedList(pageNumber, pageSize);
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
