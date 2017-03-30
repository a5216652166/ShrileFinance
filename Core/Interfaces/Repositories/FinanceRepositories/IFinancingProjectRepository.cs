namespace Core.Interfaces.Repositories.FinanceRepositories
{
    using System.Collections.Generic;
    using Entities.Produce;

    public interface IFinancingProjectRepository : IRepository<FinancingProject>
    {
        IEnumerable<FinancingProject> GetByIsFinacing(bool isFinancing);
    }
}
