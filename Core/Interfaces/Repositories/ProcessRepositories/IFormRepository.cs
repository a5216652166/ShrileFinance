namespace Core.Interfaces.Repositories.ProcessRepositories
{
    using System;
    using System.Collections.Generic;
    using Entities.Process;

    public interface IFormRepository : IRepository<Form>
    {
        IEnumerable<FormNode> GetByNode(Guid nodeId);

        IEnumerable<FormRole> GetByRole(string roleId);
    }
}
