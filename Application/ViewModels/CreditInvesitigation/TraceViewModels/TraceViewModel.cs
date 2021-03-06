﻿namespace Application.ViewModels.CreditInvesitigation.TraceViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TraceViewModel : IEntityViewModel
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
            机构变更 = 8
        }

        public enum MessageStatusEmum : byte
        {
            待生成 = 0,
            待发送 = 1,
            已发送 = 2
        }

        public Guid? Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizateName { get; set; }

        /// <summary>
        /// 报文文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作类型")]
        public MessageOperationTypeEnum Type { get; set; }

        public string TypeDesc => Type.ToString();

        /// <summary>
        /// 报文状态
        /// </summary>
        [Display(Name = "报文状态")]
        public MessageStatusEmum Status { get; set; }

        public string StatusDesc => Status.ToString();

        /// <summary>
        /// 跟踪日期
        /// </summary>
        [Display(Name = "跟踪日期")]
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 业务发生日期
        /// </summary>
        [Display(Name = "业务发生日期")]
        public DateTime SpecialDate { get; private set; }
    }
}
