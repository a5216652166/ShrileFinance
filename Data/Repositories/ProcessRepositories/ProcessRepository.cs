namespace Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities.Process;
    using Core.Interfaces.Repositories.ProcessRepositories;

    public class ProcessRepository : BaseRepository<Flow>, IProcessRepository
    {
        public ProcessRepository(MyContext context) : base(context)
        {
        }
    }
}
