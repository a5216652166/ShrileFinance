namespace Core.Entities
{
    using System;
    using Flow;
    using Interfaces;

    public class ProcessTempData : Entity, IAggregateRoot
    {
        public Guid InstanceId { get; set; }

        public string JsonData { get; set; }

        public virtual Instance Instance { get; set; }
    }
}
