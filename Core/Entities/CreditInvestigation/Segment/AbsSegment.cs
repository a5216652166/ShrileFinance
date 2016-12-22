namespace Core.Entities.CreditInvestigation.Segment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CreditInvestigation;
    using Exceptions;

    public abstract class AbsSegment : Entity
    {
        /// <summary>
        /// 信息记录标识
        /// </summary>
        public Guid RecordId { get; private set; }

        public void Packaging(StringBuilder builder)
        {
            var metas = ReflectionAndValid();

            metas.OrderBy(m => m.Position).ToList()
                .ForEach(m => builder.Append(m.GetValue()));
        }

        public int GetLength()
        {
            var metas = ReflectionAndValid();

            var meta = metas.OrderBy(m => m.Position).LastOrDefault();

            return meta.Position + meta.Length;
        }

        /// <summary>
        /// 类属性数据提取和校验
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Meta> ReflectionAndValid()
        {
            var properties = GetType().GetProperties();

            // 遍历类的属性
            foreach (var property in properties)
            {
                // 获取属性上的自定义特性
                var attrs = property.GetCustomAttributes(false);

                // 获取属性特性中的自定义的MetaCodeAttribute
                var metaCode = attrs.SingleOrDefault(m => m is MetaCodeAttribute) as MetaCodeAttribute;

                // 获取属性特性中的自定义的SegmentRuleAttribute
                var segmentRule = attrs.SingleOrDefault(m => m is SegmentRuleAttribute) as SegmentRuleAttribute;

                // 为空时,可能是那些不需要封装的字段,需要排除
                if (metaCode == null || segmentRule == null)
                {
                    continue;
                }

                // 通过属性获取当前实例化类中的对应属性的值
                var value = property.GetValue(this);

                // 必填项,位置校验
                if (!segmentRule.IsValid(value))
                {
                    throw new ArgumentAppException(
                        message: segmentRule.ErrorMessage,
                        paramName: property.Name);
                }

                // 长度,类型格式校验
                if (!metaCode.IsValid(value))
                {
                    throw new ArgumentAppException(
                        message: metaCode.ErrorMessage,
                        paramName: property.Name);
                }

                yield return new Meta(value, segmentRule.Position, metaCode.Length, metaCode.Type);
            }
        }

        /// <summary>
        /// 封装数据的包装类,方便数据的排序以及其他操作
        /// </summary>
        public class Meta
        {
            private string value;
            private int position;
            private int length;
            private MetaCodeTypeEnum type;

            public Meta(object value, int position, int length, MetaCodeTypeEnum type)
            {
                this.value = Convert.ToString(value);
                this.position = position;
                this.length = length;
                this.type = type;
            }

            public int Position
            {
                get { return position; }
            }

            public int Length
            {
                get { return length; }
            }

            public string GetValue()
            {
                var result = Padding(this.value);

                return result;
            }

            private string Padding(string value)
            {
                var result = string.Empty;

                switch (type)
                {
                    case MetaCodeTypeEnum.N:
                        result = PaddingN(value);
                        break;
                    case MetaCodeTypeEnum.AN:
                    case MetaCodeTypeEnum.Amount:
                    case MetaCodeTypeEnum.ANC:
                        result = PaddingString(value);
                        break;
                    case MetaCodeTypeEnum.Date:
                        result = PaddingDate(value);
                        break;
                    default:
                        break;
                }

                return result;
            }

            private string PaddingN(string value)
            {
                return value.PadLeft(length, '0');
            }

            private string PaddingString(string value)
            {
                return value.PadRight(length);
            }

            private string PaddingDate(string value)
            {
                return value.PadLeft(length);
            }
        }
    }
}
