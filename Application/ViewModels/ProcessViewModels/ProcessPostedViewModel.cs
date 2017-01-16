namespace Application.ViewModels.ProcessViewModels
{
    using System;

    public class ProcessPostedViewModel
    {
        public enum ProcessTypeEnum
        {
            融资 = 1,
            机构 = 2,
            授信 = 3,
            借据 = 4,
            还款 = 5,
        }

        public Guid InstanceId { get; set; }

        public Guid ActionId { get; set; }

        public string InternalOpinion { get; set; }

        public string ExnernalOpinion { get; set; }

        public string Data { get; set; }

        public ProcessTypeEnum? ProcessType { get; set; }
    }
}
