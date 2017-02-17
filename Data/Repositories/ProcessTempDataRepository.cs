namespace Data.Repositories
{
    using Core.Entities;
    using Core.Interfaces.Repositories;

    public class ProcessTempDataRepository : BaseRepository<ProcessTempData>, IProcessTempDataRepository
    {
        public ProcessTempDataRepository(MyContext context) : base(context)
        {
        }
    }
}
