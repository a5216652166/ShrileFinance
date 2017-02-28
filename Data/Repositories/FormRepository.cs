namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities.Flow;
    using Core.Interfaces.Repositories;

    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        public FormRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<FormNode> GetByNode(Guid nodeId)
        {
            return Context.Set<FormNode>().Where(m => m.NodeId == nodeId);
        }

        public IEnumerable<FormRole> GetByRole(string roleId)
        {
            return Context.Set<FormRole>().Where(m => m.RoleId == roleId);
        }
    }
}
