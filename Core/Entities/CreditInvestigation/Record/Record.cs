﻿namespace Core.Entities.CreditInvestigation.Record
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Segment;

    public enum RecordTypeEnum
    {
        机构基本信息记录 = 11,
        家族成员信息记录 = 17,

        资产负债表信息记录2007版 = 43,
        利润及利润分配表信息记录2007版 = 44,
        现金流量表信息记录2007版 = 45,
        事业单位资产负债表信息记录 = 46,
        事业单位收入支出表信息记录 = 47,

        诉讼信息记录 = 6,
        大事信息记录 = 7,

        贷款业务合同信息记录 = 8,
        贷款业务借据信息记录 = 9,
        贷款业务还款信息记录 = 10,
        贷款业务展期信息记录 = 11,
        保证合同信息记录 = 22,
        抵押合同信息记录 = 23,
        质押合同信息记录 = 24,
        欠息信息记录 = 26,
        自然人保证合同信息记录 = 32,
        自然人抵押合同信息记录 = 33,
        自然人质押合同信息记录 = 34,
    }

    public abstract class Record : Entity
    {
        protected Record()
        {
        }

        /// <summary>
        /// 信息记录类型
        /// </summary>
        public abstract RecordTypeEnum Type { get; }

        /// <summary>
        /// 报文标识
        /// </summary>
        public Guid DatagramId { get; private set; }

        /// <summary>
        /// 段集合
        /// </summary>
        public virtual ICollection<Segment> Segments { get; protected set; }

        public void Packaging(StringBuilder builder)
        {
            var segments = Segments.OrderBy(m => m.SegmentType);
            foreach (var segment in segments)
            {
                segment.Packaging(builder);
            }
        }

        /// <summary>
        /// 获取信息记录总长度
        /// </summary>
        /// <returns></returns>
        protected int GetLength()
        {
            // 新建一个字典存放反射过的类的长度
            var dict = new Dictionary<string, int>();
            var sumLength = 0;

            foreach (var segment in Segments)
            {
                var segmentName = segment.GetType().Name;

                // 如果不存在指定的键
                if (!dict.ContainsKey(segmentName))
                {
                    dict.Add(segmentName, segment.GetLength());
                }

                sumLength += dict[segmentName];
            }

            return sumLength;
        }
    }
}
