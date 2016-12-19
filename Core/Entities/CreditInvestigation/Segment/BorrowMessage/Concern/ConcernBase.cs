namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.Concern
{
    using System.ComponentModel.DataAnnotations;

    public class ConcernBase
    {
        [StringLength(4), MinLength(4), Required]
        public string 信息记录长度 { get; set; }

        [StringLength(2), MinLength(2), Required]
        public string 信息记录类型 { get; set; }

        public string 信息类别
        {
            get { return "B"; }
        }

        [StringLength(11), Required, MinLength(11)]
        public string 金融机构代码
        {
            get { return "33207991216"; }
        }

        [StringLength(80), Required]
        public string 借款人名称 { get; set; }

        [StringLength(16), MinLength(16), Required]
        public string 贷款卡编码 { get; set; }

        [StringLength(1), Required]
        public string 信息记录操作类型 { get; set; }

        [StringLength(8), Required]
        public string 业务发生日期 { get; set; }

        public string 信息记录跟踪编号
        {
            get { return string.Empty.PadLeft(20, '0'); }
        }
    }
}
