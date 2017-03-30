namespace Core.Interfaces.Repositories.ProcessRepositories
{
    using System;
    using Entities;

    public interface IProcessTempDataRepository : IRepository<ProcessTempData>
    {
        ProcessTempData GetByInstanceId(Guid instanceId);
    }
}
