namespace Core.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities.Flow;

    public interface IFormRepository : IRepository<Form>
    {
        IEnumerable<FormNode> GetByNode(Guid nodeId);

        IEnumerable<FormRole> GetByRole(string roleId);
    }
}
