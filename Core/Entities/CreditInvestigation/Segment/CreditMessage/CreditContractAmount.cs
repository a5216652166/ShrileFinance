﻿namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class CreditContractAmount
    {
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "E"; }
        }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(2, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 贷款合同金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(5, true)]
        public string CreditLimit { get; set; }

        /// <summary>
        /// 贷款余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(25, true)]
        public string CreditBalance { get; set; }
    }
}
