using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.InfomationRecords
{
    /// <summary>
    /// 2007版资产负债表信息记录
    /// </summary>
    public class LiabilitiesRecord
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string Type
        {
            get { return "G"; }
        }

        /// <summary>
        /// 货币资金
        /// </summary>
        public decimal? MonetaryFund { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TransactionAssets { get; set; }
    }
}
