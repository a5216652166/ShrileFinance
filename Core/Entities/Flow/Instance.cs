namespace Core.Entities.Flow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Instance : Entity, IAggregateRoot
    {
        public Instance()
        {
            Logs = new HashSet<Log>();
        }

        public string Title { get; set; }

        public Guid FlowId { get; set; }

        public Guid? CurrentNodeId { get; set; }

        public string CurrentUserId { get; set; }

        public DateTime? ProcessTime=> Logs.LastOrDefault()?.ProcessTime;

        public string StartUserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public InstanceStatusEnum Status { get; set; }

        public ProcessTypeEnum ProcessType { get; set; }

        public Guid? RootKey { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual Node CurrentNode { get; set; }

        public virtual AppUser CurrentUser { get; set; }

        public virtual AppUser ProcessUser => Logs.LastOrDefault()?.ProcessUser;

        public virtual AppUser StartUser { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
