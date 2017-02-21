namespace Data.Repositories
{
    using System;
    using System.Linq;
    using Core.Entities;
    using Core.Interfaces.Repositories;

    public class ProcessTempDataRepository : BaseRepository<ProcessTempData>, IProcessTempDataRepository
    {
        public ProcessTempDataRepository(MyContext context) : base(context)
        {
        }

        ProcessTempData IProcessTempDataRepository.GetByInstanceId(Guid instanceId)
        {
            var entities = GetAll(m => m.InstanceId == instanceId);

            return entities.Count() > 0 ? entities.Single() : null;
        }
    }
}
