namespace Core.Interfaces.Repositories.ProcessRepositories
{
    using Entities.Other;

    public interface IDraftRepository : IRepository<Draft>
    {
        Draft GetByUserAndPageLink(string userId, string pageLink);
    }
}
