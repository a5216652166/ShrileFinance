namespace Core.Entities.Message
{
    using System;
    using Core.Interfaces;

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

    public class MessageTrack : Entity, IAggregateRoot
    {
        public MessageTrack()
        {
            TrackDate = DateTime.Now;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 引用ID
        /// </summary>
        public Guid ReferenceId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public MessageOperationTypeEnum OperationType { get; set; }

        /// <summary>
        /// 报文状态
        /// </summary>
        public MessageStatusEmum MessageStatus { get; set; }

        /// <summary>
        /// 报文数据
        /// </summary>
        public string MessageData { get; set; }

        /// <summary>
        /// 跟踪日期
        /// </summary>
        public DateTime TrackDate { get; set; }
    }
}
