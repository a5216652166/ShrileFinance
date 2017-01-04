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
            return Context.Set<Flow>();
        }
    }
}
