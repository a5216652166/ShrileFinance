namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 事业单位收入支出
    /// </summary>
    public class InstitutionIncomeExpenditure : Entity
    {
        /// <summary>
        /// 报表类型
        /// </summary>
        public int Type { get; set; }

        public decimal? 财政补助收入 { get; set; }

        public decimal? 上级补助收入 { get; set; }

        public decimal? 附属单位缴款 { get; set; }

        public decimal? 事业收入 { get; set; }

        public decimal? 预算外资金收入 { get; set; }

        public decimal? 其他收入 { get; set; }

        public decimal? 事业收入小计 { get; set; }

        public decimal? 经营收入 { get; set; }

        public decimal? 经营收入小计 { get; set; }

        public decimal? 拨入专款 { get; set; }

        public decimal? 拨入专款小计 { get; set; }

        public decimal? 收入总计 { get; set; }

        public decimal? 拨出经费 { get; set; }

        public decimal? 上缴上级支出 { get; set; }

        public decimal? 对附属单位补助 { get; set; }

        public decimal? 事业支出 { get; set; }

        public decimal? 财政补助支出 { get; set; }

        public decimal? 预算外资金支出 { get; set; }

        public decimal? 销售税金 { get; set; }

        public decimal? 销售税金1 { get; set; }

        public decimal? 结转自筹基建 { get; set; }

        public decimal? 事业支出小计 { get; set; }

        public decimal? 经营支出 { get; set; }

        public decimal? 经营支出小计 { get; set; }

        public decimal? 拨出专款 { get; set; }

        public decimal? 专款支出 { get; set; }

        public decimal? 专款小计 { get; set; }

        public decimal? 支出总计 { get; set; }

        public decimal 事业结余 { get; set; }

        public decimal? 正常收入结余 { get; set; }

        public decimal? 收回以前年度事业支出 { get; set; }

        public decimal 经营结余 { get; set; }

        public decimal? 以前年度经营亏损 { get; set; }

        public decimal? 结余分配 { get; set; }

        public decimal? 应交所得税 { get; set; }

        public decimal? 提取专用基金 { get; set; }

        public decimal? 转入事业基金 { get; set; }

        public decimal? 其他结余分配 { get; set; }
    }
}
