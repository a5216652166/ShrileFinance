namespace Core.Interfaces.Repositories
{
    using Entities.Other;

    public interface IDraftRepository : IRepository<Draft>
    {
        Draft GetByUserAndPageLink(string userId, string pageLink);
    }
}
