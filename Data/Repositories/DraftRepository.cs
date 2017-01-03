namespace Data.Repositories
{
    using System.Linq;
    using Core.Entities.Other;
    using Core.Interfaces.Repositories;

    public class DraftRepository : BaseRepository<Draft>, IDraftRepository
    {
        public DraftRepository(MyContext context) : base(context)
        {
        }

        public Draft GetByUserAndPageLink(string userId, string pageLink)
        {
            return GetAll().FirstOrDefault(m => m.UserId == userId && m.PageLink == pageLink);
        }
    }
}
