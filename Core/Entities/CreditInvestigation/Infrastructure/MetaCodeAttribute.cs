namespace Core.Entities.CreditInvestigation
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 数据元校验(长度、类型)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MetaCodeAttribute : Attribute
    {
        public MetaCodeAttribute(int length, MetaCodeTypeEnum type)
        {
            Length = length;
            Type = type;
        }

        /// <summary>
        /// 类型
        /// </summary>
        public MetaCodeTypeEnum Type { get; private set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; private set; }

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
            var data = Convert.ToString(value);

            return ValidLength(data) && ValidType(data);
        }

        private bool ValidLength(string value)
        {
            var length = 0;
            var regx = new Regex(@"^[\u4e00-\u9fa5]$");

            foreach (var item in value)
            {
                length += regx.IsMatch(item.ToString()) ? 2 : 1;
            }

            if (length > Length)
            {
                ErrorMessage = "长度验证未通过";

                return false;
            }

            return true;
        }

        private bool ValidType(string value)
        {
            var validTypeR = true;

            // 校验类型
            var dataChars = value.ToCharArray();

            if (Type == MetaCodeTypeEnum.N)
            {
                for (int i = 0; i < dataChars.Length; i++)
                {
                    if (dataChars[i] < 0X30 || dataChars[i] > 0X39)
                    {
                        validTypeR = false;
                        ErrorMessage = "N类型校验未通过！";

                        break;
                    }
                }
            }
            else if (Type == MetaCodeTypeEnum.AN)
            {
                for (int i = 0; i < dataChars.Length; i++)
                {
                    if (dataChars[i] < 0X20 || dataChars[i] > 0X7E)
                    {
                        validTypeR = false;
                        ErrorMessage = "AN类型校验未通过！";

                        break;
                    }
                }
            }
            else if (Type == MetaCodeTypeEnum.Amount)
            {
                if (string.Empty.Equals(value))
                {
                    return true;
                }

                validTypeR = new Regex(@"^-?\d+\.\d{2}$").IsMatch(value);
                ErrorMessage = "金额类型校验未通过！";
            }

            return validTypeR;
        }
    }
}
