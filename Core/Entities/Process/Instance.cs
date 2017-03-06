namespace Core.Entities.Process
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

        public DateTime? ProcessTime => Logs.LastOrDefault()?.ProcessTime;

        public string StartUserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public InstanceStatusEnum Status { get; set; }

        public ProcessTypeEnum ProcessType => GetProcessType();

        public Guid? RootKey { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual Node CurrentNode { get; set; }

        public virtual AppUser CurrentUser { get; set; }

        public virtual AppUser ProcessUser => Logs.LastOrDefault()?.ProcessUser;

        public virtual AppUser StartUser { get; set; }

        public virtual ICollection<Log> Logs { get; set; }

        public static Guid GetProcessIdByType(ProcessTypeEnum processType)
        {
            var processId = ProcessDic().Single(m => m.Value == processType).Key;

            return processId;
        }

        private static Dictionary<Guid, ProcessTypeEnum> ProcessDic()
        {
            var dictionary = new Dictionary<Guid, ProcessTypeEnum>();

            dictionary.Add(Guid.Parse("228C8C80-06A4-E611-80C5-507B9DE4A488"), ProcessTypeEnum.融资);
            dictionary.Add(Guid.Parse("04824FE1-78D1-E611-80CA-507B9DE4A488"), ProcessTypeEnum.添加机构);
            dictionary.Add(Guid.Parse("05824FE1-78D1-E611-80CA-507B9DE4A488"), ProcessTypeEnum.授信);
            dictionary.Add(Guid.Parse("06824FE1-78D1-E611-80CA-507B9DE4A488"), ProcessTypeEnum.借据);
            dictionary.Add(Guid.Parse("07824FE1-78D1-E611-80CA-507B9DE4A488"), ProcessTypeEnum.还款);
            dictionary.Add(Guid.Parse("08824FE1-78D1-E611-80CA-507B9DE4A488"), ProcessTypeEnum.机构变更);

            return dictionary;
        }

        private ProcessTypeEnum GetProcessType()
            => ProcessDic()[FlowId];
    }
}
