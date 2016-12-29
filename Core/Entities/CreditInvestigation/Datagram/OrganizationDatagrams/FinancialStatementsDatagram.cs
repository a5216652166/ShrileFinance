namespace Core.Entities.CreditInvestigation.Datagram.OrganizationDatagrams
{
    using System.Collections.Generic;
    using Record;

    /// <summary>
    /// 财务报表信息报文
    /// </summary>
    public class FinancialStatementsDatagram : Datagram
    {
        public FinancialStatementsDatagram() : base()
        {
            ////Records = new List<AbsRecord>()
            ////{
            ////    // 2007版资产负债表信息记录
            ////    new BalanceSheetRecord(),

            ////    // 2007版现金流量表信息记录
            ////    new CashFlowRecord(),

            ////    // 2007版利润及利润分配表信息记录
            ////    new ProfitRecord(),

            ////    // 事业单位收入支出表信息记录
            ////    new InstitutionIncomeExpenditureRecord(),

            ////    // 事业单位资产负债表信息记录
            ////    new InstitutionLiabilitiesRecord()
            ////};
        }

        public override DatagramTypeEnum Type
        {
            get
            {
                return DatagramTypeEnum.财务报表信息采集报文;
            }
        }
    }
}
