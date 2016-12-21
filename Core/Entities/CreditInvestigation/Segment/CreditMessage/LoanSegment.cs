namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using AutoMapper;
    using Loan;

    public class LoanSegment : AbsSegment
    {
        public LoanSegment(Loan loan)
        {
            Mapper.Map(loan, this);

            借据编号 = loan.Id.ToString();
        }

        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true, Describe = "段标")]
        public string 信息类别
        {
            get { return "F"; }
        }

        /// <summary>
        /// 借据编号
        /// </summary>
        [MetaCode(60, MetaCodeTypeEnum.ANC), SegmentRule(2, true, Describe = "用来标识同一笔贷款合同项下的多笔放款借据的编号")]
        public string 借据编号 { get; set; }

        [MetaCode(3, MetaCodeTypeEnum.AN), SegmentRule(62, true)]
        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 借据金额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(65, true)]
        public string Principle { get; private set; }

        /// <summary>
        /// 借据余额
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(85, true)]
        public string Balance { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(105, true)]
        public string SpecialDate { get; private set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        [MetaCode(8, MetaCodeTypeEnum.N), SegmentRule(113, true)]
        public string MatureDate { get; set; }

        /// <summary>
        /// 贷款业务种类
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(121, true)]
        public string LoanBusinessTypes { get; set; }

        /// <summary>
        /// 贷款形式
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(122, true)]
        public string LoanForm { get; set; }

        /// <summary>
        /// 贷款性质
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(123, true)]
        public string LoanNature { get; set; }

        /// <summary>
        /// 贷款投向
        /// </summary>
        [MetaCode(5, MetaCodeTypeEnum.AN), SegmentRule(124, true)]
        public string LoansTo { get; set; }

        /// <summary>
        /// 贷款种类
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(129, true)]
        public string LoanTypes { get; set; }

        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(131, true)]
        public string 展期标志
        {
            get
            {
                return "2";
            }
        }

        /// <summary>
        /// 四级分类
        /// </summary>
        [MetaCode(2, MetaCodeTypeEnum.N), SegmentRule(132, false)]
        public string FourCategoryAssetsClassification { get; set; }

        /// <summary>
        /// 五级分类
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.N), SegmentRule(134, true)]
        public string FiveCategoryAssetsClassification { get; set; }
    }
}
