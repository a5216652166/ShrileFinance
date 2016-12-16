namespace Application.ViewModels.Message
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core.Entities.Message;

    public class MessageTrackViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称"), Required, MaxLength(60)]
        public string Name { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作类型")]
        public MessageOperationTypeEnum OperationType { get; set; }

        /// <summary>
        /// 报文状态
        /// </summary>
        [Display(Name = "报文状态")]
        public MessageStatusEmum MessageStatus { get; set; }
    }
}
