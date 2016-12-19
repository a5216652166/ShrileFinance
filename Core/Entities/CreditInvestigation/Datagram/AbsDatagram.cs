﻿namespace Core.Entities.CreditInvestigation.Datagram
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
        家庭成员信息报文 = 1,
        财务报表信息采集报文 = 3,
        关注信息采集报文 = 4,
        信贷业务信息文件 = 12
    }

    /// <summary>
    /// 报文抽象类
    /// </summary>
    public abstract class AbsDatagram : Entity
    {
        protected AbsDatagram()
        {
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
        public string FormatVersion
        {
            get { return "2.2"; }
        }

        /// <summary>
        /// 金融机构代码
        /// </summary>
        public string FinancialOrganizationCode
        {
            get { return AbsDatagramFile.FinancialOrganizationCode; }
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
        /// 信息记录集合
        /// </summary>
        public abstract ICollection<AbsRecord> Records { get; protected set; }

        public void Packaging(StringBuilder builder)
        {
            var header = GenerateHeader();
            var footer = GenerateFooter();

            builder.Append(header);

            if (Records.Count > 0)
            {
                // 报文体中信息记录为零时，
                // 报文头后紧跟报文尾，不留空行。
                builder.AppendLine();

                // 信息记录的组织方式按照“聚类排列”方式进行，
                // 不同种类的信息记录以规范中的编号先后为准。
                var records = Records.OrderBy(m => m.Type);
                foreach (var record in records)
                {
                    record.Packaging(builder);
                }

                builder.AppendLine();
            }

            builder.Append(footer);
        }

        /// <summary>
        /// 生成报文头
        /// </summary>
        /// <returns></returns>
        private StringBuilder GenerateHeader()
        {
            var builder = new StringBuilder();

            builder.Append(HeaderIdentity);
            builder.Append(FormatVersion);
            builder.Append(FinancialOrganizationCode);
            builder.Append(DateCreated.ToString("yyyyMMddHHmmss"));
            builder.Append(Type.ToString("D2"));
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
