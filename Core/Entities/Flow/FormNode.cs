namespace Core.Entities.Flow
{
    using System;

    public class FormNode
    {
        public FormNode()
        {
            State = FormStateEnum.禁用;
            IsOpen = false;
            IsHandler = false;
        }

        public Guid NodeId { get; set; }

        public Guid FormId { get; set; }

        public FormStateEnum State { get; set; }

        public bool IsOpen { get; set; }

        public bool IsHandler { get; set; }

        public virtual Node Node { get; set; }

        public virtual Form Form { get; set; }
    }
}
