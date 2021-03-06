﻿namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 关注信息报文
    /// </summary>
    public class ConcernDatagram : Datagram
    {
        public ConcernDatagram() : base()
        {
            ////Records = new List<AbsRecord>()
            ////{
            ////    // 大事件信息记录
            ////    new BigEventRecord(),

            ////    // 诉讼信息记录
            ////    new LitigationRecord()
            ////};
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.关注信息采集报文;
            }
        }
    }
}
