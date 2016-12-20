namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 事业单位资产负债表信息记录
    /// </summary>
    public class InstitutionLiabilitiesParagraph
    {
        /// <summary>
        /// 报表类型
        /// </summary>
        [MetaCode(1, MetaCodeTypeEnum.AN), SegmentRule(1, true)]
        public string Type
        {
            get { return "J"; }
        }

        /// <summary>
        /// 现金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(2, false)]
        public decimal? 现金 { get; set; }

        /// <summary>
        /// 银行存款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public decimal? 银行存款 { get; set; }

        /// <summary>
        /// 应收票据
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public decimal? 应收票据 { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public decimal? 应收账款 { get; set; }

        /// <summary>
        /// 预付账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public decimal? 预付账款 { get; set; }

        /// <summary>
        /// 其他应收款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public decimal? 其他应收款 { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public decimal? 材料 { get; set; }

        /// <summary>
        /// 产成品
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public decimal? 产成品 { get; set; }

        /// <summary>
        /// 对外投资
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public decimal? 对外投资 { get; set; }

        /// <summary>
        /// 固定资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, false)]
        public decimal? 固定资产 { get; set; }

        /// <summary>
        /// 无形资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, false)]
        public decimal? 无形资产 { get; set; }

        /// <summary>
        /// 资产合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, true)]
        public decimal? 资产合计 { get; set; }

        /// <summary>
        /// 拨出经费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public decimal? 拨出经费 { get; set; }

        /// <summary>
        /// 拨出专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public decimal? 拨出专款 { get; set; }

        /// <summary>
        /// 专款支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, false)]
        public decimal? 专款支出 { get; set; }

        /// <summary>
        /// 事业支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public decimal? 事业支出 { get; set; }

        /// <summary>
        /// 经营支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, false)]
        public decimal? 经营支出 { get; set; }


        /// <summary>
        /// 成本费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public decimal? 成本费用 { get; set; }

        /// <summary>
        /// 销售税金2
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public decimal? 销售税金 { get; set; }

        /// <summary>
        /// 上缴上级支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(382, false)]
        public decimal? 上缴上级支出 { get; set; }

        /// <summary>
        /// 对附属单位补助
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(402, false)]
        public decimal? 对附属单位补助 { get; set; }

        /// <summary>
        /// 结转自筹基建
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(422, false)]
        public decimal? 结转自筹基建 { get; set; }

        /// <summary>
        /// 支出合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(442, true)]
        public decimal? 支出合计 { get; set; }

        /// <summary>
        /// 资产部类总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(462, true)]
        public decimal? 资产部类总计 { get; set; }

        /// <summary>
        /// 借记款项
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(482, false)]
        public decimal? 借记款项 { get; set; }

        /// <summary>
        /// 应付票据
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(502, false)]
        public decimal? 应付票据 { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(522, false)]
        public decimal? 应付账款 { get; set; }

        /// <summary>
        /// 预收账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(542, false)]
        public decimal? 预收账款 { get; set; }

        /// <summary>
        /// 其他应付款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(562, false)]
        public decimal? 其他应付款 { get; set; }

        /// <summary>
        /// 应缴预算款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(582, false)]
        public decimal? 应缴预算款 { get; set; }

        /// <summary>
        /// 应缴财政专户款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(602, false)]
        public decimal? 应缴财政专户款 { get; set; }

        /// <summary>
        /// 应交税金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(622, false)]
        public decimal? 应交税金 { get; set; }

        /// <summary>
        /// 负债合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(642, true)]
        public decimal? 负债合计 { get; set; }

        /// <summary>
        /// 事业基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(662, false)]
        public decimal? 事业基金 { get; set; }

        /// <summary>
        /// 一般基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(682, false)]
        public decimal? 一般基金 { get; set; }

        /// <summary>
        /// 投资基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(702, false)]
        public decimal? 投资基金 { get; set; }

        /// <summary>
        /// 固定基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(722, false)]
        public decimal? 固定基金 { get; set; }

        /// <summary>
        /// 专用基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(742, false)]
        public decimal? 专用基金 { get; set; }

        /// <summary>
        /// 事业结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(762, false)]
        public decimal? 事业结余 { get; set; }

        /// <summary>
        /// 经营结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(782, false)]
        public decimal? 经营结余 { get; set; }

        /// <summary>
        /// 净资产合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(802, true)]
        public decimal? 净资产合计 { get; set; }

        /// <summary>
        /// 财政补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(822, false)]
        public decimal? 财政补助收入 { get; set; }

        /// <summary>
        /// 上级补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(842, false)]
        public decimal? 上级补助收入 { get; set; }

        /// <summary>
        /// 拨入专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(862, false)]
        public decimal? 拨入专款 { get; set; }

        /// <summary>
        /// 事业收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(882, false)]
        public decimal? 事业收入 { get; set; }

        /// <summary>
        /// 经营收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(902, false)]
        public decimal? 经营收入 { get; set; }

        /// <summary>
        /// 附属单位缴款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(922, false)]
        public decimal? 附属单位缴款 { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(942, false)]
        public decimal? 其他收入 { get; set; }

        /// <summary>
        /// 收入合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(962, true)]
        public decimal? 收入合计 { get; set; }

        /// <summary>
        /// 负债部类总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(982, true)]
        public decimal? 负债部类总计 { get; set; }
    }
}
