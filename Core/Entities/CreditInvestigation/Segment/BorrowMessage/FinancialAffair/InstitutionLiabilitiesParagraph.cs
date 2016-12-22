using Core.Entities.Customers.Enterprise;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 事业单位资产负债表信息记录
    /// </summary>
    public class InstitutionLiabilitiesParagraph : AbsSegment
    {
        public InstitutionLiabilitiesParagraph() { }

        public InstitutionLiabilitiesParagraph(InstitutionLiabilities institutionLiabilities)
        {
            AutoMapper.Mapper.Map(institutionLiabilities, this);
        }

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
        public string 现金 { get; set; }

        /// <summary>
        /// 银行存款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(22, false)]
        public string 银行存款 { get; set; }

        /// <summary>
        /// 应收票据
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(42, false)]
        public string 应收票据 { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(62, false)]
        public string 应收账款 { get; set; }

        /// <summary>
        /// 预付账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(82, false)]
        public string 预付账款 { get; set; }

        /// <summary>
        /// 其他应收款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(102, false)]
        public string 其他应收款 { get; set; }

        /// <summary>
        /// 材料
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(122, false)]
        public string 材料 { get; set; }

        /// <summary>
        /// 产成品
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(142, false)]
        public string 产成品 { get; set; }

        /// <summary>
        /// 对外投资
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(162, false)]
        public string 对外投资 { get; set; }

        /// <summary>
        /// 固定资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(182, false)]
        public string 固定资产 { get; set; }

        /// <summary>
        /// 无形资产
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(202, false)]
        public string 无形资产 { get; set; }

        /// <summary>
        /// 资产合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(222, true)]
        public string 资产合计 { get; set; }

        /// <summary>
        /// 拨出经费
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(242, false)]
        public string 拨出经费 { get; set; }

        /// <summary>
        /// 拨出专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(262, false)]
        public string 拨出专款 { get; set; }

        /// <summary>
        /// 专款支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(282, false)]
        public string 专款支出 { get; set; }

        /// <summary>
        /// 事业支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(302, false)]
        public string 事业支出 { get; set; }

        /// <summary>
        /// 经营支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(322, false)]
        public string 经营支出 { get; set; }


        /// <summary>
        /// 成本费用
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(342, false)]
        public string 成本费用 { get; set; }

        /// <summary>
        /// 销售税金2
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(362, false)]
        public string 销售税金 { get; set; }

        /// <summary>
        /// 上缴上级支出
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(382, false)]
        public string 上缴上级支出 { get; set; }

        /// <summary>
        /// 对附属单位补助
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(402, false)]
        public string 对附属单位补助 { get; set; }

        /// <summary>
        /// 结转自筹基建
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(422, false)]
        public string 结转自筹基建 { get; set; }

        /// <summary>
        /// 支出合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(442, true)]
        public string 支出合计 { get; set; }

        /// <summary>
        /// 资产部类总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(462, true)]
        public string 资产部类总计 { get; set; }

        /// <summary>
        /// 借记款项
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(482, false)]
        public string 借记款项 { get; set; }

        /// <summary>
        /// 应付票据
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(502, false)]
        public string 应付票据 { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(522, false)]
        public string 应付账款 { get; set; }

        /// <summary>
        /// 预收账款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(542, false)]
        public string 预收账款 { get; set; }

        /// <summary>
        /// 其他应付款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(562, false)]
        public string 其他应付款 { get; set; }

        /// <summary>
        /// 应缴预算款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(582, false)]
        public string 应缴预算款 { get; set; }

        /// <summary>
        /// 应缴财政专户款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(602, false)]
        public string 应缴财政专户款 { get; set; }

        /// <summary>
        /// 应交税金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(622, false)]
        public string 应交税金 { get; set; }

        /// <summary>
        /// 负债合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(642, true)]
        public string 负债合计 { get; set; }

        /// <summary>
        /// 事业基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(662, false)]
        public string 事业基金 { get; set; }

        /// <summary>
        /// 一般基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(682, false)]
        public string 一般基金 { get; set; }

        /// <summary>
        /// 投资基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(702, false)]
        public string 投资基金 { get; set; }

        /// <summary>
        /// 固定基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(722, false)]
        public string 固定基金 { get; set; }

        /// <summary>
        /// 专用基金
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(742, false)]
        public string 专用基金 { get; set; }

        /// <summary>
        /// 事业结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(762, false)]
        public string 事业结余 { get; set; }

        /// <summary>
        /// 经营结余
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(782, false)]
        public string 经营结余 { get; set; }

        /// <summary>
        /// 净资产合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(802, true)]
        public string 净资产合计 { get; set; }

        /// <summary>
        /// 财政补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(822, false)]
        public string 财政补助收入 { get; set; }

        /// <summary>
        /// 上级补助收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(842, false)]
        public string 上级补助收入 { get; set; }

        /// <summary>
        /// 拨入专款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(862, false)]
        public string 拨入专款 { get; set; }

        /// <summary>
        /// 事业收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(882, false)]
        public string 事业收入 { get; set; }

        /// <summary>
        /// 经营收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(902, false)]
        public string 经营收入 { get; set; }

        /// <summary>
        /// 附属单位缴款
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(922, false)]
        public string 附属单位缴款 { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(942, false)]
        public string 其他收入 { get; set; }

        /// <summary>
        /// 收入合计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(962, true)]
        public string 收入合计 { get; set; }

        /// <summary>
        /// 负债部类总计
        /// </summary>
        [MetaCode(20, MetaCodeTypeEnum.AN), SegmentRule(982, true)]
        public string 负债部类总计 { get; set; }
    }
}
