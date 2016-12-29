namespace Core.Entities.CreditInvestigation.DatagramFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Datagram;
    using Interfaces;

    public enum DatagramFileType
    {
        借款人基本信息文件 = 11,
        信贷业务信息文件 = 12,
        机构基本信息采集报文文件 = 51
    }

    /// <summary>
    /// 报文文件抽象类
    /// </summary>
    public abstract class DatagramFile : Entity, IAggregateRoot
    {
        /// <summary>
        /// 金融机构代码
        /// </summary>
        public const string FINANCIALORGANIZATIONCODE = "33207991216";

        protected DatagramFile()
        {
        }

        protected DatagramFile(int serialNumber)
        {
            DateCreated = DateTime.Now;
            SerialNumber = serialNumber.ToString("D4");
        }

        /// <summary>
        /// 金融机构代码
        /// </summary>
        public virtual string FinancialOrganizationCode
        {
            get { return FINANCIALORGANIZATIONCODE; }
        }

        /// <summary>
        /// 报文文件种类
        /// </summary>
        public abstract DatagramFileType Type { get; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// 报文生成日期
        /// </summary>
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 报文集合
        /// </summary>
        public virtual ICollection<Datagram> Datagrams { get; protected set; }

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

            // TODO: 使用业务发生日期
            builder.Append(DateTime.Now.ToString("yyMMdd"));
            builder.Append(Type.ToString("D").PadLeft(2, '0'));
            builder.Append(1);
            builder.Append(SerialNumber);
            builder.Append(0);
            builder.Append(0);

            return $"{builder.ToString()}.txt";
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public byte[] GetBuffer()
        {
            var content = Packaging();

            return Encoding.GetEncoding("GB2312").GetBytes(content);
        }

        public Datagram GetDatagram(DatagramTypeEnum type)
        {
            return Datagrams.Single(m => m.Type == type);
        }

        /// <summary>
        /// 封装
        /// </summary>
        /// <returns></returns>
        private string Packaging()
        {
            var builder = new StringBuilder();

            foreach (var datagram in Datagrams.OrderBy(m => m.Type))
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
