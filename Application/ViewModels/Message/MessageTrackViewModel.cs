namespace Application.ViewModels.Message
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MessageTrackViewModel : IEntityViewModel
    {
        public enum MessageOperationTypeEnum : byte
        {
            添加机构 = 0,
            签订授信合同 = 1,
            借款 = 2,
            还款 = 3,
            终止合同 = 4,
            逾期 = 5,
            合同变更 = 6,
            欠息 = 7,
        }

        public enum MessageStatusEmum : byte
        {
            待生成 = 0,
            待发送 = 1,
            已发送 = 2,
            待反馈 = 3,
            不发送 = 4,
        }

        public Guid? Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作类型")]
        public MessageOperationTypeEnum OperationType { get; set; }

        public string OperationTypeDesc
        {
            get
            { return OperationType.ToString(); }
        }

        /// <summary>
        /// 报文状态
        /// </summary>
        [Display(Name = "报文状态")]
        public MessageStatusEmum MessageStatus { get; set; }

        public string MessageStatusDesc
        {
            get
            { return MessageStatus.ToString(); }
        }

        [Display(Name = "跟踪日期")]
        public DateTime TrackDate { get; set; }
    }
}
