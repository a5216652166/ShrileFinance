namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using Core.Entities.Flow;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class InstanceViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Flow { get; set; }

        public string CurrentNode { get; set; }

        public string CurrentUser { get; set; }

        public string ProcessUser { get; set; }

        public DateTime? ProcessTime { get; set; }

        public string StartUser { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public InstanceStatusEnum Status { get; set; }
    }
}
