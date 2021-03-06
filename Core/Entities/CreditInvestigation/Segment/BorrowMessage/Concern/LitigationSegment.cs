﻿namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Customers.Enterprise;

    /// <summary>
    /// 诉讼事件
    /// </summary>
    public class LitigationSegment : Segment
    {
        public LitigationSegment(Litigation litigation)
        {
            Mapper.Map(litigation, this);
            DateTime = Convert.ToDateTime(litigation.DateTime).ToString("yyyyMMdd");
        }

        protected LitigationSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public override char SegmentType
        {
            get { return 'D'; }
        }

        [Display(Name = "被起诉流水号"), MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "报报送机构用于标识一起诉讼的唯一编号")]
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        [Display(Name = "起诉人姓名"), MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(62, true)]
        public string ProsecuteName { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(142, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        [Display(Name = "判决执行金额"), MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(145, true)]
        public string Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        [Display(Name = "判决执行日期"), MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(165, true)]
        public string DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [Display(Name = "执行结果"), MetaCode(100, MetaCodeTypeEnum.ANC), SegmentRule(173, true)]
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        [Display(Name = "被起诉原因"), MetaCode(300, MetaCodeTypeEnum.ANC), SegmentRule(273, true)]
        public string Reason { get; set; }
    }
}
