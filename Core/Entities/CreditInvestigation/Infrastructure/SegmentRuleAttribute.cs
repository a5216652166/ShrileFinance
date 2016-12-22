namespace Core.Entities.CreditInvestigation
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class SegmentRuleAttribute : Attribute
    {
        public SegmentRuleAttribute(int position, bool isRequired)
        {
            Position = position;
            IsRequired = isRequired;
        }

        /// <summary>
        /// 位置
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// 必填
        /// </summary>
        public bool IsRequired { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// 校验函数
        /// </summary>
        /// <param name="value">被校验对象</param>
        /// <returns>校验结果</returns>
        public bool IsValid(object value)
        {
            if (IsRequired && value == null)
            {
                ErrorMessage = "必填验证未通过";

                return false;
            }

            return true;
        }
    }
}
