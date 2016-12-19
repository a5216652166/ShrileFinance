using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    /// <summary>
    /// 质押
    /// </summary>
    public class GuaranteePledge
    {
        public string 信息类别
        {
            get { return "F"; }
        }
        /// <summary>
        /// 质押合同编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 质押序号
        /// </summary>
        public string PledgeNumber { get; set; }

        /// <summary>
        /// 出质人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string CreditcardCode { get; set; }

        public string 币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 质押物价值
        /// </summary>
        public string CollateralValue { get; set; }

        /// <summary>
        /// 合同签订日期
        /// </summary>
        public string SigningDate { get; set; }

        /// <summary>
        /// 质押物种类
        /// </summary>
        public string PledgeType { get; set; }

        public string 质押币种
        {
            get { return "CNY"; }
        }

        /// <summary>
        /// 质押物金额
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// 合同有效状态
        /// </summary>
        public string EffectiveState { get; set; }
    }
}
