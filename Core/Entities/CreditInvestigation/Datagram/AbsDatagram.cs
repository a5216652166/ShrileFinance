namespace Core.Entities.CreditInvestigation.Datagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DatagramFile;
    using Record;

    public enum DatagramTypeEnum
    {
        机构基本信息报文 = 0,
        家族成员信息报文 = 1,
        财务报表信息采集报文 = 3,
        关注信息采集报文 = 4,
        贷款业务信息采集报文 = 11,
        保理业务信息采集报文 = 12,
        票据贴现业务信息采集报文 = 13,
        贸易融资业务信息采集报文 = 14,
        信用证业务信息采集报文 = 15,
        保函业务信息采集报文 = 16,
        银行承兑汇票业务信息采集报文 = 17,
        公开授信信息采集报文 = 18,
        担保业务信息采集报文 = 19,
        垫款业务信息采集报文 = 20,
        欠息信息采集报文 = 21,
        不良信贷资产处置信息采集报文 = 61
    }

    /// <summary>
    /// 报文抽象类
    /// </summary>
    public abstract class AbsDatagram : Entity
    {
        protected AbsDatagram()
        {
            Records = new HashSet<AbsRecord>();
            DateCreated = DateTime.Now;
        }

        /// <summary>
        /// 报文头标识
        /// </summary>
        public string HeaderIdentity
        {
            get { return "A"; }
        }

        /// <summary>
        /// 报文尾标识
        /// </summary>
        public string FooterIdentity
        {
            get { return "Z"; }
        }

        /// <summary>
        /// 报文格式版本号
        /// </summary>
        public virtual string FormatVersion
        {
            get { return "2.1"; }
        }

        /// <summary>
        /// 金融机构代码
        /// </summary>
        public string FinancialOrganizationCode
        {
            get { return AbsDatagramFile.FINANCIAL_ORGANIZATION_CODE; }
        }

        /// <summary>
        /// 报文生成时间
        /// </summary>
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 报文类型
        /// </summary>
        public abstract DatagramTypeEnum Type { get; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string Reserved
        {
            get { return string.Empty.PadLeft(30, ' '); }
        }

        /// <summary>
        /// 报文文件标识
        /// </summary>
        public Guid DatagramFileId { get; private set; }

        /// <summary>
        /// 信息记录集合
        /// </summary>
        public virtual ICollection<AbsRecord> Records { get; protected set; }

        /// <summary>
        /// 添加信息记录
        /// </summary>
        /// <param name="record">信息记录</param>
        /// <returns>流式 API</returns>
        public virtual AbsDatagram AddRecord(AbsRecord record)
        {
            Records.Add(record);

            return this;
        }

        public void Packaging(StringBuilder builder)
        {
            var header = GenerateHeader();
            var footer = GenerateFooter();

            builder.Append(header);
            builder.AppendLine();

            if (Records.Count > 0)
            {
                // 信息记录的组织方式按照“聚类排列”方式进行，
                // 不同种类的信息记录以规范中的编号先后为准。
                var records = Records.OrderBy(m => m.Type);
                foreach (var record in records)
                {
                    record.Packaging(builder);

                    // 信息记录之间换行。
                    builder.AppendLine();
                }
            }

            builder.Append(footer);
        }

        /// <summary>
        /// 生成报文头
        /// </summary>
        /// <returns></returns>
        protected virtual StringBuilder GenerateHeader()
        {
            var builder = new StringBuilder();

            builder.Append(HeaderIdentity);
            builder.Append(FormatVersion);
            builder.Append(FinancialOrganizationCode);
            builder.Append(DateCreated.ToString("yyyyMMddHHmmss"));
            builder.Append(Type.ToString("D").PadLeft(2, '0'));
            builder.Append(Reserved.PadLeft(30));

            return builder;
        }

        /// <summary>
        /// 生成报文尾
        /// </summary>
        /// <returns></returns>
        private StringBuilder GenerateFooter()
        {
            var builder = new StringBuilder();

            builder.Append(FooterIdentity);
            builder.Append(Records.Count.ToString("D10"));

            return builder;
        }
    }
}
