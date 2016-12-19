using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Type
        {
            get { return "K"; }
        }

        /// <summary>
        /// 财政补助收入
        /// </summary>
        public decimal? 财政补助收入 { get; set; }

        /// <summary>
        /// 上级补助收入
        /// </summary>
        public decimal? 上级补助收入 { get; set; }

        /// <summary>
        /// 附属单位缴款
        /// </summary>
        public decimal? 附属单位缴款 { get; set; }

        /// <summary>
        /// 事业收入
        /// </summary>
        public decimal? 事业收入 { get; set; }

        /// <summary>
        /// 预算外资金收入
        /// </summary>
        public decimal? 预算外资金收入 { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        public decimal? 其他收入 { get; set; }

        /// <summary>
        /// 事业收入小计
        /// </summary>
        public decimal? 事业收入小计 { get; set; }

        /// <summary>
        /// 经营收入
        /// </summary>
        public decimal? 经营收入 { get; set; }

        /// <summary>
        /// 经营收入小计
        /// </summary>
        public decimal? 经营收入小计 { get; set; }

        /// <summary>
        /// 拨入专款
        /// </summary>
        public decimal? 拨入专款 { get; set; }

        /// <summary>
        /// 拨入专款小计
        /// </summary>
        public decimal? 拨入专款小计 { get; set; }

        /// <summary>
        /// 收入总计
        /// </summary>
        public decimal? 收入总计 { get; set; }

        /// <summary>
        /// 拨出经费
        /// </summary>
        public decimal? 拨出经费 { get; set; }

        /// <summary>
        /// 上缴上级支出
        /// </summary>
        public decimal? 上缴上级支出 { get; set; }

        /// <summary>
        /// 对附属单位补助
        /// </summary>
        public decimal? 对附属单位补助 { get; set; }

        /// <summary>
        /// 事业支出
        /// </summary>
        public decimal? 事业支出 { get; set; }

        /// <summary>
        /// 财政补助支出
        /// </summary>
        public decimal? 财政补助支出 { get; set; }

        /// <summary>
        /// 预算外资金支出
        /// </summary>
        public decimal? 预算外资金支出 { get; set; }

        /// <summary>
        /// 销售税金
        /// </summary>
        public decimal? 销售税金 { get; set; }

        /// <summary>
        /// 结转自筹基建
        /// </summary>
        public decimal? 结转自筹基建 { get; set; }

        /// <summary>
        /// 事业支出小计
        /// </summary>
        public decimal? 事业支出小计 { get; set; }

        /// <summary>
        /// 经营支出
        /// </summary>
        public decimal? 经营支出 { get; set; }

        /// <summary>
        /// 经营支出小计
        /// </summary>
        public decimal? 经营支出小计 { get; set; }

        /// <summary>
        /// 拨出专款
        /// </summary>
        public decimal? 拨出专款 { get; set; }

        /// <summary>
        /// 专款支出
        /// </summary>
        public decimal? 专款支出 { get; set; }

        /// <summary>
        /// 专款小计
        /// </summary>
        public decimal? 专款小计 { get; set; }

        /// <summary>
        /// 支出总计
        /// </summary>
        public decimal? 支出总计 { get; set; }

        /// <summary>
        /// 事业结余
        /// </summary>
        public decimal 事业结余 { get; set; }

        /// <summary>
        /// 正常收入结余
        /// </summary>
        public decimal? 正常收入结余 { get; set; }

        /// <summary>
        /// 收回以前年度事业支出
        /// </summary>
        public decimal? 收回以前年度事业支出 { get; set; }

        /// <summary>
        /// 经营结余
        /// </summary>
        public decimal 经营结余 { get; set; }

        /// <summary>
        /// 以前年度经营亏损
        /// </summary>
        public decimal? 以前年度经营亏损 { get; set; }

        /// <summary>
        /// 结余分配
        /// </summary>
        public decimal? 结余分配 { get; set; }

        /// <summary>
        /// 应交所得税
        /// </summary>
        public decimal? 应交所得税 { get; set; }

        /// <summary>
        /// 提取专用基金
        /// </summary>
        public decimal? 提取专用基金 { get; set; }

        /// <summary>
        /// 转入事业基金
        /// </summary>
        public decimal? 转入事业基金 { get; set; }

        /// <summary>
        /// 其他结余分配
        /// </summary>
        public decimal? 其他结余分配 { get; set; }
    }
}
