namespace Core.Entities.CreditInvestigation.Segment.CreditMessage
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreditBase
    {
        [StringLength(4)]
        public string 信息记录长度 { get; set; }

        [StringLength(2)]
        public string 信息记录类型 { get; set; }

        public string 信息类别
        {
            get { return "B"; }
        }

        public string 金融机构代码
        {
            get { return "33207991216"; }
        }

        /// <summary>
        /// 贷款卡编码/中征码
        /// </summary>
        [StringLength(16), MinLength(16)]
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 贷款合同编号
        /// </summary>
        [StringLength(60)]
        public string CreditContractCode { get; set; }

        [StringLength(1)]
        public string 信息记录操作类型 { get; set; }

        [StringLength(8)]
        public string 业务发生日期
        {
            get { return DateTime.Now.ToString("yyyyMMdd"); }
        }

        public string 信息记录跟踪编号
        {
            get { return string.Empty.PadLeft(20, ' '); }
        }
    }
}
