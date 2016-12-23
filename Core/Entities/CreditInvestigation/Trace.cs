namespace Core.Entities.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using DatagramFile;
    using Exceptions;
    using Interfaces;

    public enum TraceTypeEnum : byte
    {
        添加机构 = 0,
        签订授信合同 = 1,
        借款 = 2,
        还款 = 3,
        终止合同 = 4,
        逾期 = 5,
        合同变更 = 6,
        欠息 = 7,
    }

    public enum TraceStatusEmum : byte
    {
        待生成 = 0,
        待发送 = 1,
        已发送 = 2,
        待反馈 = 3,
        不发送 = 4,
    }

    public class Trace : Entity, IAggregateRoot
    {
        public Trace(Guid referenceId, TraceTypeEnum type, int serialNumber, DateTime dateCreated, string name = null)
        {
            Name = name;
            Type = type;
            ReferenceId = referenceId;
            SerialNumber = serialNumber;

            TraceDate = DateTime.Now.Date;
            Status = TraceStatusEmum.待生成;
        }

        protected Trace()
        {
        }

        /// <summary>
        /// 跟踪日期
        /// </summary>
        public DateTime TraceDate { get; private set; }

        /// <summary>
        /// 生成日期
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 引用ID
        /// </summary>
        public Guid ReferenceId { get; private set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public TraceTypeEnum Type { get; private set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 报文状态
        /// </summary>
        public TraceStatusEmum Status { get; private set; }

        /// <summary>
        /// 报文顺序号
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// 报文文件标识
        /// </summary>
        public Guid? DatagramFileId { get; private set; }

        /// <summary>
        /// 报文文件
        /// </summary>
        public virtual AbsDatagramFile DatagramFile { get; private set; }

        /// <summary>
        /// 添加报文文件
        /// </summary>
        /// <param name="datagramFile">报文文件</param>
        public void AddDatagram(AbsDatagramFile datagramFile)
        {
            //if (Status != TraceStatusEmum.待生成)
            //{
            //    throw new InvalidOperationAppException("报文已生成。");
            //}

            DatagramFile = datagramFile;
            //Status = TraceStatusEmum.待发送;
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <returns>文件名、流</returns>
        public KeyValuePair<string, Stream> ToFile()
        {
            ////if (Status != TraceStatusEmum.待发送)
            ////{
            ////    throw new InvalidOperationAppException("下载前必须生成报文。");
            ////}

            // 文件名
            string fileName = $"{DatagramFile.GenerateFilename()}.txt";

            // 流
            var memoryStream = new MemoryStream(Encoding.GetEncoding("GB2312").GetBytes(DatagramFile.Packaging()));

            return new KeyValuePair<string, Stream>(fileName, memoryStream);
        }
    }
}
