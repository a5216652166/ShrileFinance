namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using OrganizationViewModels;

    public class ProcessDataViewModel
    {
        public Guid InstanceId { get; set; }

        public OrganizationChangeViewModel OrganizationChange { get; set; }
        public OrganizationViewModel Organization { get; set; }
    }
}
