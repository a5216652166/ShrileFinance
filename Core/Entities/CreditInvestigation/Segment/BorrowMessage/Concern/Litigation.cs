﻿namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure;

    /// <summary>
    /// 诉讼事件
    /// </summary>
    public class Litigation
    {
        [MetaCode(1, MetaCodeAttribute.DataTypeEnum.AN), SectionRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "D"; }
        }

        [Display(Name = "被起诉流水号"), MetaCode(60, MetaCodeAttribute.DataTypeEnum.ANC), SectionRule(2, true, Describe = "报报送机构用于标识一起诉讼的唯一编号")]
        public string ChargedSerialNumber { get; set; }

        /// <summary>
        /// 起诉人姓名
        /// </summary>
        [Display(Name = "起诉人姓名"), MetaCode(80, MetaCodeAttribute.DataTypeEnum.ANC), SectionRule(62, true)]
        public string ProsecuteName { get; set; }

        [MetaCode(3, MetaCodeAttribute.DataTypeEnum.AN), SectionRule(142, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 判决执行金额
        /// </summary>
        [Display(Name = "判决执行金额"), MetaCode(20, MetaCodeAttribute.DataTypeEnum.AN), SectionRule(145, true)]
        public string Money { get; set; }

        /// <summary>
        /// 判决执行日期
        /// </summary>
        [Display(Name = "判决执行日期"),MetaCode(8, MetaCodeAttribute.DataTypeEnum.N), SectionRule(165, true)]
        public string DateTime { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [Display(Name = "执行结果"), MetaCode(100, MetaCodeAttribute.DataTypeEnum.ANC), SectionRule(173, true)]
        public string Result { get; set; }

        /// <summary>
        /// 被起诉原因
        /// </summary>
        [Display(Name = "被起诉原因"), MetaCode(300, MetaCodeAttribute.DataTypeEnum.ANC), SectionRule(273, true)]
        public string Reason { get; set; }
    }
}
