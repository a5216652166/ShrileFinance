namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using Core.Entities.Flow;

    public class ProcessTempDataViewModel<T> where T : class
    {
        public Guid Id { get; set; } = Guid.Empty;

        public Guid InstanceId { get; set; } = Guid.Empty;

        public string JsonData { get; set; } = string.Empty;

        public virtual Instance Instance { get; set; }

        public virtual T ObjData { get; set; }
    }
}
