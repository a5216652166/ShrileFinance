namespace Core.Entities.Process
{
    using System.Collections.Generic;
    using Interfaces;

    public class Flow : Entity, IAggregateRoot
    {
        public Flow()
        {
            Nodes = new HashSet<Node>();
        }

        public string Name { get; set; }

        public virtual ICollection<Node> Nodes { get; set; }
    }
}
