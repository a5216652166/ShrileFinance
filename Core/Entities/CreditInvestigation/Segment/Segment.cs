namespace Core.Entities.CreditInvestigation.Segment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CreditInvestigation;
    using Exceptions;

    public abstract class Segment : Entity
    {
        protected Segment()
        {
        }

        /// <summary>
        /// 信息类别（段标）
        /// </summary>
        public abstract char SegmentType { get; }

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
            var currentPosition = 0;
            var currentLength = 0;
            var properties = GetType().GetProperties();

            // 遍历类的属性
            foreach (var property in properties)
            {
                // 获取属性上的自定义特性
                var attrs = property.GetCustomAttributes(false);

                // 获取属性特性中的自定义的SegmentRuleAttribute
                var segmentRule = attrs.SingleOrDefault(m => m is SegmentRuleAttribute) as SegmentRuleAttribute;

                if (segmentRule != null && segmentRule.Position > currentPosition)
                {
                    // 获取属性特性中的自定义的MetaCodeAttribute
                    var metaCode = attrs.SingleOrDefault(m => m is MetaCodeAttribute) as MetaCodeAttribute;

                    currentPosition = segmentRule.Position;
                    currentLength = metaCode.Length;
                }
            }

            return currentPosition + currentLength - 1;
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

            public int Position => position;

            public int Length => length;

            public string GetValue()
                => Padding(value);

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
                int gblength = Encoding.GetEncoding("gb2312").GetByteCount(value);
                int enlength = value.Length;

                value = value.PadLeft(length, '0');
                value = value.Substring(gblength - enlength, value.Length);

                return value;
            }

            private string PaddingString(string value)
            {
                int gblength = Encoding.GetEncoding("gb2312").GetByteCount(value);
                int enlength = value.Length;

                value = value.PadRight(length);

                value = value.Substring(0, value.Length - (gblength - enlength));

                return value;
            }

            private string PaddingDate(string value)
            {
                int gblength = Encoding.GetEncoding("gb2312").GetByteCount(value);
                int enlength = value.Length;

                value = value.PadLeft(length);
                value = value.Substring(gblength - enlength, value.Length);

                return value;
            }
        }
    }
}
