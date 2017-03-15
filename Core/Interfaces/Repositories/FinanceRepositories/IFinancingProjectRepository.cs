namespace Core.Interfaces.Repositories
{
    using System.Collections.Generic;
    using Entities.Produce;

    public interface IFinancingProjectRepository : IRepository<FinancingProject>
    {
        IEnumerable<FinancingProject> GetByIsFinacing(bool isFinancing);
    }
}
