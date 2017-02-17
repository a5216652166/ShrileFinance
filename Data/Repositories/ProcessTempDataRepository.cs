namespace Data.Repositories
{
    using System;
    using Core.Entities;
    using Core.Interfaces.Repositories;

    public class ProcessTempDataRepository : BaseRepository<ProcessTempData>, IProcessTempDataRepository
    {
        public ProcessTempDataRepository(MyContext context) : base(context)
        {
        }
    }
}
