namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System;
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 财务报表信息报文
    /// </summary>
    public class FinancialStatementsDatagram : AbsDatagram
    {
        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.财务报表信息采集报文;
            }
        }

        public override ICollection<AbsRecord> Records { get; protected set; }
    }
}
