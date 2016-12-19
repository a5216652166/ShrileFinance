﻿namespace Core.Entities.CreditInvestigation.Record
{
    using System.Collections.Generic;
    using System.Text;
    using Segment;

    public enum RecordTypeEnum
    {
        借款人基本信息文件 = 11,
        信贷业务信息文件 = 12
    }

    public abstract class AbsRecord : Entity
    {
        public RecordTypeEnum Type { get; set; }

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
