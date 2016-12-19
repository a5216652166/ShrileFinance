using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 2007版利润及利润分配表信息记录
    /// </summary>
    public class ProfitsParagraph
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string Type
        {
            get { return "H"; }
        }

        /// <summary>
        /// 营业收入
        /// </summary>
        public decimal BusinessIncome { get; set; }

        /// <summary>
        /// 营业成本
        /// </summary>
        public decimal? OperatingCost { get; set; }

        /// <summary>
        /// 营业税金及附加
        /// </summary>
        public decimal? SalesTax { get; set; }

        /// <summary>
        /// 销售费用
        /// </summary>
        public decimal? SellingExpenses { get; set; }

        /// <summary>
        /// 管理费用
        /// </summary>
        public decimal? ManagementExpenses { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        public decimal FinancialExpenses { get; set; }

        /// <summary>
        /// 资产减值损失
        /// </summary>
        public decimal? AssetsimpairmentLoss { get; set; }

        /// <summary>
        /// 公允价值变动净收益
        /// </summary>
        public decimal? FairIncome { get; set; }

        /// <summary>
        /// 投资净收益
        /// </summary>
        public decimal? NetInvestmentIncome { get; set; }

        /// <summary>
        /// 对联营企业和合营企业的投资收益
        /// </summary>
        public decimal? EnterpriseInvestmentIncome { get; set; }

        /// <summary>
        /// 营业利润
        /// </summary>
        public decimal OperatingProfit { get; set; }

        /// <summary>
        /// 营业外收入
        /// </summary>
        public decimal? OperatingIncome { get; set; }

        /// <summary>
        /// 营业外支出
        /// </summary>
        public decimal? OperatingExpenditure { get; set; }

        /// <summary>
        /// 非流动资产损失
        /// </summary>
        public decimal? NonCurrentAssetsLoss { get; set; }

        /// <summary>
        /// 利润总额
        /// </summary>
        public decimal GrossProfit { get; set; }

        /// <summary>
        /// 所得税费用
        /// </summary>
        public decimal? IncomeTaxExpense { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        public decimal NetProfit { get; set; }

        /// <summary>
        /// 基本每股收益
        /// </summary>
        public decimal? BasicEarningsShare { get; set; }

        /// <summary>
        /// 稀释每股收益
        /// </summary>
        public decimal? DilutedEarningsShare { get; set; }
    }
}
