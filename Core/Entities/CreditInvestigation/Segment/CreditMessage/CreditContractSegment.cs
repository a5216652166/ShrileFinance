﻿namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using AutoMapper;
    using Loan;

    public class CreditContractSegment : Segment
    {
        public CreditContractSegment(CreditContract credit)
        {
            Mapper.Map(credit, this);

            InstitutionChName = credit.Organization.Property.InstitutionChName;

            switch (credit.EffectiveStatus)
            {
                case CreditContractStatusEnum.生效:
                case CreditContractStatusEnum.未结清:
                    EffectiveStatus = "1";
                    break;
                case CreditContractStatusEnum.失效:
                    EffectiveStatus = "2";
                    break;
                default:
                    break;
            }

            EffectiveDate = credit.EffectiveDate.ToString("yyyyMMdd");
            ExpirationDate = credit.ExpirationDate.ToString("yyyyMMdd");
            HasGuarantee = credit.HasGuarantee ? "1" : "2";
        }

        protected CreditContractSegment() : base()
        {
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public override char SegmentType
        {
            get { return 'D'; }
        }

        /// <summary>
        /// 借款人姓名(根据贷款合同中机构ID获取中征码手动映射)
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "借款人在工商部门的注册名称")]
        public string InstitutionChName { get; set; }

        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(82, false, Describe = "填写用于标识此贷款合同所对应的授信信息编号。对于法人账户透支类的贷款，以“XHZH”填报，不作为贷款合同的主键，仅用于区分一般贷款")]
        public string 授信协议号码
        {
            get { return string.Empty.PadLeft(60, ' '); }
        }

        /// <summary>
        /// 授信合同生效日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(142, true)]
        public string EffectiveDate { get; set; }

        /// <summary>
        /// 授信合同终止日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.Date), SegmentRule(150, true)]
        public string ExpirationDate { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(158, true)]
        public string 银团标志
        {
            get { return "2"; }
        }

        /// <summary>
        /// 合同有效状态(需手动转换征信里面只有是/否)
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(159, true)]
        public string EffectiveStatus { get; set; }

        /// <summary>
        /// 担保标志(需手动转换征信里面只有是/否)
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(160, true)]
        public string HasGuarantee { get; set; }
    }
}
