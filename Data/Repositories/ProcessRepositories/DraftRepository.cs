namespace Data.Repositories
{
    using System.Linq;
    using Core.Entities.Other;
    using Core.Interfaces.Repositories.ProcessRepositories;

    public class DraftRepository : BaseRepository<Draft>, IDraftRepository
    {
        public DraftRepository(MyContext context) : base(context)
        {
        }

        Draft IDraftRepository.GetByUserAndPageLink(string userId, string pageLink)
        {
            return GetAll().FirstOrDefault(m => m.UserId == userId && m.PageLink == pageLink);
        }
    }
}
