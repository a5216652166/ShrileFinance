namespace Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities.Process;
    using Core.Interfaces.Repositories;
    using X.PagedList;

    public class ProcessRepository : BaseRepository<Process>, IProcessRepository
    {
        public ProcessRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<Process> GetAll() =>
            Context.Set<Process>();

        public override IQueryable<Process> GetAll(Expression<Func<Process, bool>> predicate) =>
            Context.Set<Process>().Where(predicate);
    }
}
