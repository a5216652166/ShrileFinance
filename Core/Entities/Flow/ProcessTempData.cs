namespace Core.Entities
{
    using System;
    using Interfaces;

    public class ProcessTempData : Entity, IAggregateRoot
    {
        public Guid ReferenceId { get; set; }

        public string Data { get; set; }
    }
}
