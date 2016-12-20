namespace Core.Entities.CreditInvestigation.Record
{
    using System.Collections.Generic;
    using System.Text;
    using Segment;

    public enum RecordTypeEnum
    {
        机构基本信息记录 = 11,
        资产负债表信息记录2007版 = 12,
        现金流量表信息记录2007版 = 13,
        事业单位收入支出表信息记录 = 14,
        事业单位资产负债表信息记录 = 15,
        利润及利润分配表信息记录2007版 = 16,
        家族成员信息记录 = 17,
        大事件信息记录 = 18,
        诉讼信息记录 = 19,

        贷款业务合同信息记录 = 8,
        贷款业务借据信息记录 = 9,
        贷款业务还款信息记录 = 10,
        保证合同信息记录 = 22,
        抵押合同信息记录 = 23,
        质押合同信息记录 = 24,
        欠息信息记录 = 26,
        自然人保证合同信息记录 = 32,
        自然人抵押合同信息记录 = 33,
        自然人质押合同信息记录 = 34
    }

    public abstract class AbsRecord : Entity
    {
        public abstract RecordTypeEnum Type { get; }

        public abstract ICollection<AbsSegment> Segments { get; protected set; }

        public void Packaging(StringBuilder builder)
        {
            foreach (var segment in Segments)
            {
                segment.Packaging(builder);
            }
        }
    }
}
