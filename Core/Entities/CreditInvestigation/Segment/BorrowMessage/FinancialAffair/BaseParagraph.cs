namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    using System;
    using Customers.Enterprise;
    using DatagramFile;

    /// <summary>
    /// 信息记录基础段
    /// </summary>
    public class BaseParagraph : AbsSegment
    {
        public BaseParagraph()
        {
        }

        public BaseParagraph(FinancialAffairs financialAffairs, Customers.Enterprise.Organization organization, string type)
        {
            报表类型 = type;
            借款人名称 = organization.Property.InstitutionChName;
            贷款卡编号 = organization.LoanCardCode;
            报表年份 = financialAffairs.Year.ToString();
            报表类型细分 = financialAffairs.TypeSubdivision.ToString();
            审计事务所名称 = financialAffairs.AuditFirm;
            审计人员名称 = financialAffairs.AuditorName;
            信息记录操作类型 = "1";
            // TODO 财务实体中添加审计时间字段
            审计时间 = DateTime.Now.ToString("yyyyMMdd");
            业务发生日期 = DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 信息记录长度
        /// </summary>
        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(1, true)]
        public string 信息记录长度 { get; set; }

        /// <summary>
        /// 信息记录类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(5, true)]
        public string 信息记录类型 { get; set; }

        /// <summary>
        /// 信息类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(7, true)]
        public string 信息类别
        {
            // 填B表示基础段
            get { return "B"; }
        }

        /// <summary>
        /// 金融机构代码
        /// </summary>
        [MetaCode(11, MetaCodeTypeEnum.AN), SegmentRule(8, true)]
        public string 金融机构代码
        {
            get { return AbsDatagramFile.FinancialOrganizationCode; }
        }

        /// <summary>
        /// 借款人名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(19, true)]
        public string 借款人名称 { get; set; }

        /// <summary>
        /// 贷款卡编号
        /// </summary>
        [MetaCode(16, MetaCodeTypeEnum.AN), SegmentRule(99, true)]
        public string 贷款卡编号 { get; set; }

        /// <summary>
        /// 报表年份(格式:YYYY)
        /// </summary>
        [MetaCode(4, MetaCodeTypeEnum.N), SegmentRule(115, true)]
        public string 报表年份 { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(119, true)]
        public string 报表类型 { get; set; }

        /// <summary>
        /// 报表类型细分
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(121, true)]
        public string 报表类型细分 { get; set; }

        /// <summary>
        /// 审计事务所名称
        /// </summary>
        [MetaCode(80, MetaCodeTypeEnum.ANC), SegmentRule(122, false)]
        public string 审计事务所名称 { get; set; }

        [MetaCode(30, MetaCodeTypeEnum.ANC), SegmentRule(202, false)]
        public string 审计人员名称 { get; set; }

        /// <summary>
        /// 审计时间(格式:YYYYMMDD)
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(232, false)]
        public string 审计时间 { get; set; }

        /// <summary>
        /// 信息记录操作类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(240, true)]
        public string 信息记录操作类型 { get; set; }

        /// <summary>
        /// 业务发生日期(格式:YYYYMMDD)
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(241, true)]
        public string 业务发生日期 { get; set; }

        /// <summary>
        /// 信息记录跟踪编号
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(249, true)]
        public string 信息记录跟踪编号
        {
            get { return string.Empty.PadLeft(20, '0'); }
        }
    }
}
