namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Datagram;
    using Interfaces;

    public enum DatagramFileType
    {
        借款人基本信息文件 = 11,
        信贷业务信息文件 = 12
    }

    /// <summary>
    /// 报文文件抽象类
    /// </summary>
    public abstract class AbsDatagramFile : Entity, IAggregateRoot
    {
        /// <summary>
        /// 金融机构代码
        /// </summary>
        public const string FinancialOrganizationCode = "33207991216";

        protected AbsDatagramFile(string serialNumber)
        {
            DateCreated = DateTime.Now;
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// 数据生成日期
        /// </summary>
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 报文文件种类
        /// </summary>
        public abstract DatagramFileType Type { get; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// 报文集合
        /// </summary>
        public abstract ICollection<AbsDatagram> Datagrams { get; }

        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <returns></returns>
        public string GenerateFilename()
        {
            var builder = new StringBuilder();

            builder.Append(1);
            builder.Append(1);
            builder.Append(FinancialOrganizationCode);
            builder.Append(DateTime.Now.ToString("yyMMdd"));
            builder.Append(Type);
            builder.Append(1);
            builder.Append(SerialNumber);
            builder.Append(0);
            builder.Append(0);

            return builder.ToString();
        }

        /// <summary>
        /// 封装
        /// </summary>
        /// <returns></returns>
        public string Packaging()
        {
            var builder = new StringBuilder();

            foreach (var datagram in Datagrams)
            {
                // 封装报文
                datagram.Packaging(builder);

                // 报文之间用两个换行符分隔
                builder.AppendLine();
                builder.AppendLine();
            }

            if (Datagrams.Count > 0)
            {
                // 移除最后的换行分隔符
                builder.Remove(builder.Length - 4, 4);
            }

            return builder.ToString();
        }
    }
}
