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
        public void Packaging(StringBuilder builder)
        {
            var metas = ReflectionAndValid();

            metas.OrderBy(m => m.Position).ToList()
                .ForEach(m => builder.Append(m.GetValue()));
        }

        private IEnumerable<Meta> ReflectionAndValid()
        {
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var attrs = property.GetCustomAttributes(false);
                var metaCode = attrs.SingleOrDefault(m => m is MetaCodeAttribute) as MetaCodeAttribute;
                var segmentRule = attrs.SingleOrDefault(m => m is SegmentRuleAttribute) as SegmentRuleAttribute;

                if (metaCode == null || segmentRule == null)
                {
                    continue;
                }

                var value = property.GetValue(this);

                if (!segmentRule.IsValid(value))
                {
                    throw new ArgumentAppException(
                        message: segmentRule.ErrorMessage,
                        paramName: property.Name);
                }

                if (!metaCode.IsValid(value))
                {
                    throw new ArgumentAppException(
                        message: metaCode.ErrorMessage,
                        paramName: property.Name);
                }

                yield return new Meta(value, segmentRule.Position, metaCode.Length, metaCode.Type);
            }
        }

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

            public int Position { get { return position; } }

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
