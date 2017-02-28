namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using Core.Entities.Flow;

    public class FormViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public FormStateEnum State { get; set; }

        public bool IsOpen { get; set; }

        public bool IsHandler { get; set; }
    }
}
