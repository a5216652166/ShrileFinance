﻿namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DatagramFile;

    /// <summary>
    /// 信贷业务基础段
    /// </summary>
    public class CreditBase
    {
        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(1, true, Describe = "本信息记录的长度")]
        public string 信息记录长度 { get; set; }

        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(5, true, Describe = "本信息记录的类别")]
        public string 信息记录类型 { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(7, true, Describe = "信息类别")]
        public string 信息类别
        {
            get { return "B"; }
        }

        [MetaCode(11, MetaCodeTypeEnum.AN), SegmentRule(8, true, Describe = "填写数据发生机构的代码")]
        public string 金融机构代码
        {
            get { return AbsDatagramFile.FinancialOrganizationCode; }
        }

        /// <summary>
        /// 贷款卡编码/中征码
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(19, true, Describe = "中国人民银行统一编发给借款人、担保人、出资人的代码，作为其在企业征信系统的唯一标识")]
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 贷款合同编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(35, true, Describe = "金融机构自己定义和使用的，用于唯一标识本机构内一笔贷款业务的号码")]
        public string CreditContractCode { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(95, true)]
        public string 信息记录操作类型
        {
            get { return "1"; }
        }

        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(96, true)]
        public string 业务发生日期
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }

        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(104, true)]
        public string 信息记录跟踪编号
        {
            get { return string.Empty.PadLeft(20, ' '); }
        }
    }
}
