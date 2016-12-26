namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    using Core.Entities.Customers.Enterprise;

    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class IncomeExpenditureParagraph : AbsSegment
    {
        public IncomeExpenditureParagraph(InstitutionIncomeExpenditure incomeExpenditure)
        {
            AutoMapper.Mapper.Map(incomeExpenditure, this);
        }

        protected IncomeExpenditureParagraph() : base()
        {
        }

        /// <summary>
        /// 信息类别
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.ANC), SegmentRule(1, true)]
        public override char SegmentType
        {
            get { return 'K'; }
        }

        /// <summary>
        /// 财政补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(2, false)]
        public string 财政补助收入 { get; set; }

        /// <summary>
        /// 上级补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(22, false)]
        public string 上级补助收入 { get; set; }

        /// <summary>
        /// 附属单位缴款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(42, false)]
        public string 附属单位缴款 { get; set; }

        /// <summary>
        /// 事业收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(62, false)]
        public string 事业收入 { get; set; }

        /// <summary>
        /// 预算外资金收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(82, false)]
        public string 预算外资金收入 { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(102, false)]
        public string 其他收入 { get; set; }

        /// <summary>
        /// 事业收入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(122, false)]
        public string 事业收入小计 { get; set; }

        /// <summary>
        /// 经营收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(142, false)]
        public string 经营收入 { get; set; }

        /// <summary>
        /// 经营收入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(162, false)]
        public string 经营收入小计 { get; set; }

        /// <summary>
        /// 拨入专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(182, false)]
        public string 拨入专款 { get; set; }

        /// <summary>
        /// 拨入专款小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(202, false)]
        public string 拨入专款小计 { get; set; }

        /// <summary>
        /// 收入总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(222, false)]
        public string 收入总计 { get; set; }

        /// <summary>
        /// 拨出经费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(242, false)]
        public string 拨出经费 { get; set; }

        /// <summary>
        /// 上缴上级支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(262, false)]
        public string 上缴上级支出 { get; set; }

        /// <summary>
        /// 对附属单位补助
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(282, false)]
        public string 对附属单位补助 { get; set; }

        /// <summary>
        /// 事业支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(302, false)]
        public string 事业支出 { get; set; }

        /// <summary>
        /// 财政补助支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(322, false)]
        public string 财政补助支出 { get; set; }

        /// <summary>
        /// 预算外资金支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(342, false)]
        public string 预算外资金支出 { get; set; }

        /// <summary>
        /// 销售税金1
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(362, false)]
        public string 销售税金 { get; set; }

        /// <summary>
        /// 结转自筹基建
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(382, false)]
        public string 结转自筹基建 { get; set; }

        /// <summary>
        /// 事业支出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(402, false)]
        public string 事业支出小计 { get; set; }

        /// <summary>
        /// 经营支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(422, false)]
        public string 经营支出 { get; set; }

        /// <summary>
        /// 销售税金2
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(442, false)]
        public string 销售税金1 { get; set; }

        /// <summary>
        /// 经营支出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(462, false)]
        public string 经营支出小计 { get; set; }

        /// <summary>
        /// 拨出专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(482, false)]
        public string 拨出专款 { get; set; }

        /// <summary>
        /// 专款支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(502, false)]
        public string 专款支出 { get; set; }

        /// <summary>
        /// 专款小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(522, false)]
        public string 专款小计 { get; set; }

        /// <summary>
        /// 支出总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(542, false)]
        public string 支出总计 { get; set; }

        /// <summary>
        /// 事业结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(562, true)]
        public string 事业结余 { get; set; }

        /// <summary>
        /// 正常收入结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(582, false)]
        public string 正常收入结余 { get; set; }

        /// <summary>
        /// 收回以前年度事业支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(602, false)]
        public string 收回以前年度事业支出 { get; set; }

        /// <summary>
        /// 经营结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(622, true)]
        public string 经营结余 { get; set; }

        /// <summary>
        /// 以前年度经营亏损
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(642, false)]
        public string 以前年度经营亏损 { get; set; }

        /// <summary>
        /// 结余分配
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(662, false)]
        public string 结余分配 { get; set; }

        /// <summary>
        /// 应交所得税
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(682, false)]
        public string 应交所得税 { get; set; }

        /// <summary>
        /// 提取专用基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(702, false)]
        public string 提取专用基金 { get; set; }

        /// <summary>
        /// 转入事业基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(722, false)]
        public string 转入事业基金 { get; set; }

        /// <summary>
        /// 其他结余分配
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.Amount), SegmentRule(742, false)]
        public string 其他结余分配 { get; set; }
    }
}
