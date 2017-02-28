namespace Core.Entities.Flow
{
    using System;
    using System.Collections.Generic;
    using Identity;

    public class Node : Entity
    {
        public Node()
        {
            Actions = new HashSet<FAction>();
        }

        public string Name { get; set; }

        public Guid FlowId { get; set; }

        public string RoleId { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual AppRole Role { get; set; }

        public virtual ICollection<FAction> Actions { get; set; }
    }
}
