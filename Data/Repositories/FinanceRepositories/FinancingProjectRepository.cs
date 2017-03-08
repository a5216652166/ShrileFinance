namespace Data.Repositories
{
    using System.Collections.Generic;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;

    public class FinancingProjectRepository : BaseRepository<FinancingProject>, IFinancingProjectRepository
    {
        public FinancingProjectRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<FinancingProject> GetByIsFinacing(bool isFinancing)
        {
            return GetAll(m => m.IsFinancing == isFinancing);
        }
    }
}
