namespace Core.Entities.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public Trace(Guid referenceId, TraceTypeEnum type, DateTime specialDate, string name = null)
        {
            Name = name;
            Type = type;
            ReferenceId = referenceId;
            ////SerialNumber = serialNumber;
            SpecialDate = specialDate;
            DateCreated = DateTime.Now.Date;
            Status = TraceStatusEmum.待生成;
        }

        protected Trace()
        {
        }

        /// <summary>
        /// 业务发生日期
        /// </summary>
        public DateTime SpecialDate { get; private set; }

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

        /////// <summary>
        /////// 报文顺序号
        /////// </summary>
        ////public int SerialNumber { get; set; }

        /// <summary>
        /// 跟踪日期
        /// </summary>
        public DateTime DateCreated { get; private set; }

        /// <summary>
        /// 报文文件
        /// </summary>
        public virtual ICollection<DatagramFile.DatagramFile> DatagramFiles { get; private set; }

        /// <summary>
        /// 添加报文文件
        /// </summary>
        /// <param name="files">报文文件</param>
        public void AddDatagram(IEnumerable<DatagramFile.DatagramFile> files)
        {
            if (Status != TraceStatusEmum.待生成 && Status != TraceStatusEmum.待发送)
            {
                throw new InvalidOperationAppException("当前状态不可生成报文。");
            }

            foreach (var file in files)
            {
                var old = DatagramFiles.FirstOrDefault(m => m.Type == file.Type);
                if (old != null)
                {
                    DatagramFiles.Remove(old);
                }

                if (file.Datagrams.Sum(m => m.Records.Count) > 0)
                {
                    DatagramFiles.Add(file);
                }
            }

            Status = TraceStatusEmum.待发送;
        }
    }
}
