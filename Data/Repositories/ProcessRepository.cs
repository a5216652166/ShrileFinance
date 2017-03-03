namespace Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities.Process;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class ProcessRepository : BaseRepository<Flow>, IProcessRepository
    {
        public ProcessRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<Flow> GetAll() =>
            Context.Set<Flow>();

        public override IQueryable<Flow> GetAll(Expression<Func<Flow, bool>> predicate) =>
            Context.Set<Flow>().Where(predicate);
    }
}
