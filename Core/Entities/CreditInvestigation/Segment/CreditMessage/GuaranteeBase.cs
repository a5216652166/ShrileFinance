using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    public class GuaranteeBase
    {
        public string 信息记录长度 { get; set; }

        public string 信息记录类型 { get; set; }

        public string 信息类别
        {
            get { return "B"; }
        }

        public string 金融机构代码 { get; set; }

        /// <summary>
        /// 中征码/贷款卡编码
        /// </summary>
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 主合同编码
        /// </summary>
        public string CreditId { get; set; }

        public string 信贷业务种类
        {
            get { return "1"; }
        }

        public string 信息记录操作类型
        {
            get { return "1"; }
        }

        public string 业务发生日期
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }

        public string 信息记录跟踪编号
        {
            get{ return string.Empty.PadLeft(20, '0');}
        }
    }
}
