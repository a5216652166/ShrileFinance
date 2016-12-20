namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 事业单位收入支出表信息记录
    /// </summary>
    public class IncomeExpenditureParagraph
    {
        /// <summary>
        /// 报表类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string Type
        {
            get { return "K"; }
        }

        /// <summary>
        /// 财政补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(2, false)]
        public decimal? 财政补助收入 { get; set; }

        /// <summary>
        /// 上级补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public decimal? 上级补助收入 { get; set; }

        /// <summary>
        /// 附属单位缴款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public decimal? 附属单位缴款 { get; set; }

        /// <summary>
        /// 事业收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public decimal? 事业收入 { get; set; }

        /// <summary>
        /// 预算外资金收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public decimal? 预算外资金收入 { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public decimal? 其他收入 { get; set; }

        /// <summary>
        /// 事业收入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public decimal? 事业收入小计 { get; set; }

        /// <summary>
        /// 经营收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public decimal? 经营收入 { get; set; }

        /// <summary>
        /// 经营收入小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public decimal? 经营收入小计 { get; set; }

        /// <summary>
        /// 拨入专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, false)]
        public decimal? 拨入专款 { get; set; }

        /// <summary>
        /// 拨入专款小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, false)]
        public decimal? 拨入专款小计 { get; set; }

        /// <summary>
        /// 收入总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, false)]
        public decimal? 收入总计 { get; set; }

        /// <summary>
        /// 拨出经费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public decimal? 拨出经费 { get; set; }

        /// <summary>
        /// 上缴上级支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public decimal? 上缴上级支出 { get; set; }

        /// <summary>
        /// 对附属单位补助
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, false)]
        public decimal? 对附属单位补助 { get; set; }

        /// <summary>
        /// 事业支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public decimal? 事业支出 { get; set; }

        /// <summary>
        /// 财政补助支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, false)]
        public decimal? 财政补助支出 { get; set; }

        /// <summary>
        /// 预算外资金支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public decimal? 预算外资金支出 { get; set; }

        /// <summary>
        /// 销售税金1
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public decimal? 销售税金1 { get; set; }

        /// <summary>
        /// 结转自筹基建
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(382, false)]
        public decimal? 结转自筹基建 { get; set; }

        /// <summary>
        /// 事业支出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(402, false)]
        public decimal? 事业支出小计 { get; set; }

        /// <summary>
        /// 经营支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(422, false)]
        public decimal? 经营支出 { get; set; }

        /// <summary>
        /// 销售税金2
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(442, false)]
        public decimal? 销售税金2 { get; set; }

        /// <summary>
        /// 经营支出小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(462, false)]
        public decimal? 经营支出小计 { get; set; }

        /// <summary>
        /// 拨出专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(482, false)]
        public decimal? 拨出专款 { get; set; }

        /// <summary>
        /// 专款支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(502, false)]
        public decimal? 专款支出 { get; set; }

        /// <summary>
        /// 专款小计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(522, false)]
        public decimal? 专款小计 { get; set; }

        /// <summary>
        /// 支出总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(542, false)]
        public decimal? 支出总计 { get; set; }

        /// <summary>
        /// 事业结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(562, true)]
        public decimal 事业结余 { get; set; }

        /// <summary>
        /// 正常收入结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(582, false)]
        public decimal? 正常收入结余 { get; set; }

        /// <summary>
        /// 收回以前年度事业支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(602, false)]
        public decimal? 收回以前年度事业支出 { get; set; }

        /// <summary>
        /// 经营结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(622, true)]
        public decimal 经营结余 { get; set; }

        /// <summary>
        /// 以前年度经营亏损
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(642, false)]
        public decimal? 以前年度经营亏损 { get; set; }

        /// <summary>
        /// 结余分配
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(662, false)]
        public decimal? 结余分配 { get; set; }

        /// <summary>
        /// 应交所得税
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(682, false)]
        public decimal? 应交所得税 { get; set; }

        /// <summary>
        /// 提取专用基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(702, false)]
        public decimal? 提取专用基金 { get; set; }

        /// <summary>
        /// 转入事业基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(722, false)]
        public decimal? 转入事业基金 { get; set; }

        /// <summary>
        /// 其他结余分配
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(742, false)]
        public decimal? 其他结余分配 { get; set; }
    }
}
