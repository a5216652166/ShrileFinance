namespace Core.Interfaces.Repositories
{
    using System;
    using Entities;

    public interface IProcessTempDataRepository : IRepository<ProcessTempData>
    {
        ProcessTempData GetByInstanceId(Guid instanceId);
    }
}
