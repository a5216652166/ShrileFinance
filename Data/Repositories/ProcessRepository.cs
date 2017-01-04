namespace Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities.Flow;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class ProcessRepository : BaseRepository<Flow>, IFlowRepository
    {
        public ProcessRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<Flow> GetAll()
        {
            return base.GetAll();
        }

        public override IQueryable<Flow> GetAll(Expression<Func<Flow, bool>> predicate)
        {
            return base.GetAll(predicate);
        }

        public override IPagedList<Flow> PagedList(Expression<Func<Flow, bool>> predicate, int pageNumber, int pageSize)
        {
            return base.PagedList(predicate, pageNumber, pageSize);
        }
    }
}
