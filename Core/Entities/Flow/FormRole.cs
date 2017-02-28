namespace Core.Entities.Flow
{
    using System;
    using Identity;

    public class FormRole
    {
        public string RoleId { get; set; }

        public Guid FormId { get; set; }

        public FormStateEnum State
        {
            get { return FormStateEnum.禁用; }
        }

        public virtual AppRole Role { get; set; }

        public virtual Form Form { get; set; }
    }
}
