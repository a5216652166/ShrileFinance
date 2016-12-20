using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    /// <summary>
    /// 信息记录基础段
    /// </summary>
    public class BaseParagraph : AbsSegment
    {
        /// <summary>
        /// 信息记录长度
        /// </summary>
        public int 信息记录长度 { get; set; }

        /// <summary>
        /// 信息记录类型
        /// </summary>
        public int 信息记录类型 { get; set; }

        /// <summary>
        /// 信息类别
        /// </summary>
        public string 信息类别
        {
            // 填B表示基础段
            get { return "B"; }
        }

        /// <summary>
        /// 金融机构代码
        /// </summary>
        public string 金融机构代码
        {
            get { return ""; }
        }

        /// <summary>
        /// 借款人名称
        /// </summary>
        public string 借款人名称 { get; set; }

        /// <summary>
        /// 贷款卡编号
        /// </summary>
        public string 贷款卡编号 { get; set; }

        /// <summary>
        /// 报表年份(格式:YYYY)
        /// </summary>
        public int 报表年份 { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        public int 报表类型 { get; set; }

        /// <summary>
        /// 报表类型细分
        /// </summary>
        public int 报表类型细分 { get; set; }

        /// <summary>
        /// 审计事务所名称
        /// </summary>
        public string 审计事务所名称 { get; set; }

        /// <summary>
        /// 审计名称(格式:YYYYMMDD)
        /// </summary>
        public int 审计时间 { get; set; }

        /// <summary>
        /// 信息记录操作类型
        /// </summary>
        public int 信息记录操作类型 { get; set; }

        /// <summary>
        /// 业务发生日期(格式:YYYYMMDD)
        /// </summary>
        public int 业务发生日期 { get; set; }

        /// <summary>
        /// 信息记录跟踪编号
        /// </summary>
        public string 信息记录跟踪编号 { get; set; }
    }
}
