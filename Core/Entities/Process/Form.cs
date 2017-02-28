namespace Core.Entities.Process
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Form : Entity, IAggregateRoot
    {
        public Form()
        {
            Nodes = new HashSet<FormNode>();
            Roles = new HashSet<FormRole>();
        }

        public Guid FlowId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public byte Sort { get; set; }

        public virtual Process Process { get; set; }

        public virtual ICollection<FormNode> Nodes { get; set; }

        public virtual ICollection<FormRole> Roles { get; set; }
    }
}
