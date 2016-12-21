namespace Core.Entities.CreditInvestigation.Segment
{
    using System;
    using System.Reflection;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public abstract class AbsSegment : Entity
    {

        public void Packaging(StringBuilder builder)
        {
            // TODO: 反射遍历属性
            //throw new NotImplementedException();
            List<Test> list = new List<Test>();

            // 获取属性上的自定义特性
            foreach (PropertyInfo propInfo in this.GetType().GetProperties())
            {
                var metaAttrs = propInfo.GetCustomAttributes(typeof(MetaCodeAttribute), true)
                    .FirstOrDefault() as MetaCodeAttribute;
                var segmentAttrs = propInfo.GetCustomAttributes(typeof(SegmentRuleAttribute), true)
                    .FirstOrDefault() as SegmentRuleAttribute;

                // 带有特性的属性
                if (metaAttrs != null && segmentAttrs != null)
                {
                    list.Add(new Test
                    {
                        ProperInfo = propInfo,
                        MetaCode = metaAttrs,
                        SegmentRule = segmentAttrs,
                    });
                }
            }

            // 排序
            list.OrderBy(l => l.SegmentRule.Position);

            try
            {
                foreach (var item in list)
                {
                    switch (item.MetaCode.Type)
                    {
                        case MetaCodeTypeEnum.N:
                            builder.Append(
                                item.ProperInfo.GetValue(this, null).ToString()
                                    .PadRight(item.MetaCode.Length, '0')
                            );
                            break;
                        case MetaCodeTypeEnum.AN:
                        case MetaCodeTypeEnum.ANC:
                            builder.Append(
                                item.ProperInfo.GetValue(this, null).ToString()
                                    .PadLeft(item.MetaCode.Length, ' ')
                            );
                            break;
                        case MetaCodeTypeEnum.Date:
                            builder.Append(
                                item.ProperInfo.GetValue(this, null).ToString()
                                    .PadRight(item.MetaCode.Length, ' ')
                             );
                            break;
                        case MetaCodeTypeEnum.Amount:
                            builder.Append(
                              item.ProperInfo.GetValue(this, null).ToString()
                                  .PadRight(item.MetaCode.Length, ' ')
                            );
                            break;
                    };
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private class Test
        {
            public PropertyInfo ProperInfo { get; set; }

            public MetaCodeAttribute MetaCode { get; set; }

            public SegmentRuleAttribute SegmentRule { get; set; }
        }
    }
}
