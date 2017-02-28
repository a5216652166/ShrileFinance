namespace Core.Entities.Flow
{
    using System;
    using Interfaces;

    public class Log : Entity
    {
        public Guid? InstanceId { get; set; }

        public Guid NodeId { get; set; }

        public Guid ActionId { get; set; }

        public string ProcessUserId { get; set; }

        public DateTime ProcessTime { get; set; }

        public string Content { get; set; }

        public AuditOpinion Opinion { get; set; }

        public virtual Instance Instance { get; set; }

        public virtual Node Node { get; set; }

        public virtual FAction Action { get; set; }

        public virtual AppUser ProcessUser { get; set; }
    }
}
