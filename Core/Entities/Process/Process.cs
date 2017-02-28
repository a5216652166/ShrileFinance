namespace Core.Entities.Process
{
    using System.Collections.Generic;
    using Interfaces;

    public class Process : Entity, IAggregateRoot
    {
        public Process()
        {
            Nodes = new HashSet<Node>();
        }

        public string Name { get; set; }

        public virtual ICollection<Node> Nodes { get; set; }
    }
}
