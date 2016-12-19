namespace Core.Entities.CreditInvestigation.Datagram
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DatagramFile;
    using Record;

    public enum DatagramType
    {
        借款人基本信息文件 = 11,
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
        public abstract byte Type { get; }

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
        public ICollection<AbsRecord> Records { get; protected set; }

        /// <summary>
        /// 封装
        /// </summary>
        public void Packaging(StringBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
