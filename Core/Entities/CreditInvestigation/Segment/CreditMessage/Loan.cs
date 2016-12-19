namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Loan
    {
        public string 信息类别
        {
            get { return "F"; }
        }

        /// <summary>
        /// 借据编号
        /// </summary>
        [StringLength(60),Required]
        public string Id { get; set; }

        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 借据金额
        /// </summary>
        [StringLength(20),Required]
        public decimal Principle { get; private set; }

        /// <summary>
        /// 借据余额
        /// </summary>
        [StringLength(20),Required]
        public decimal Balance { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        [StringLength(8),Required]
        public DateTime SpecialDate { get; private set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        [StringLength(8),Required]
        public DateTime MatureDate { get; private set; }

        /// <summary>
        /// 贷款业务种类
        /// </summary>
        [StringLength(1),Required]
        public string LoanBusinessTypes { get; set; }

        /// <summary>
        /// 贷款形式
        /// </summary>
        [StringLength(1),Required]
        public string LoanForm { get; set; }

        /// <summary>
        /// 贷款性质
        /// </summary>
        [StringLength(1), Required]
        public string LoanNature { get; set; }

        /// <summary>
        /// 贷款投向
        /// </summary>
        [StringLength(5), Required]
        public string LoansTo { get; set; }

        /// <summary>
        /// 贷款种类
        /// </summary>
        [StringLength(2), Required]
        public string LoanTypes { get; set; }

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
        [StringLength(2)]
        public string FourCategoryAssetsClassification { get; set; }

        /// <summary>
        /// 五级分类
        /// </summary>
        [StringLength(1), Required]
        public string FiveCategoryAssetsClassification { get; private set; }
    }
}
