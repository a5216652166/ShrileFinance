namespace Core.Entities.Message
{
    using System;
    using System.Text.RegularExpressions;

    public class IsRequiredAndTypeAttribute : Attribute
    {
        public IsRequiredAndTypeAttribute(bool isRequired, DataTypeEnum dataType)
        {
            IsRequired = isRequired;
            DataType = dataType;
        }

        public enum DataTypeEnum
        {
            ANC = 0,
            AN = 1,
            N = 2,
            Amount = 3
        }

        /// <summary>
        /// 类型
        /// </summary>
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 错误提示
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

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

            var data = value == null ? string.Empty : value.ToString();

            var validTypeR = true;

            // 校验类型
            var dataChars = data.ToCharArray();

            if (DataType == DataTypeEnum.N)
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
            else if (DataType == DataTypeEnum.AN)
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
            else if (DataType == DataTypeEnum.Amount)
            {
                validTypeR = new Regex(@"^-?\d+\.\d{2}$").IsMatch(data);

                ErrorMessage = "金额类型校验未通过！";
            }

            if (!validTypeR)
            {
                return false;
            }

            return validTypeR;
        }
    }

    public class LocationAndLengthAttribute : Attribute
    {
        public LocationAndLengthAttribute(int dataLocation, int dataLength)
        {
            DataLocation = dataLocation;
            DataLength = dataLength;
        }

        /// <summary>
        /// 位置
        /// </summary>
        public int DataLocation { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int DataLength { get; set; }

        /// <summary>
        /// 错误提示
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 校验函数
        /// </summary>
        /// <param name="value">被校验对象</param>
        /// <returns>校验结果</returns>
        public bool IsValid(object value)
        {
            var data = value == null ? string.Empty : value.ToString();

            if (data.Length != DataLength)
            {
                ErrorMessage = "长度校验未通过！";

                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// 段规则校验(位置、是否必填)
    /// </summary>
    public class SectionRuleAttribute : Attribute
    {
        public SectionRuleAttribute(int position, bool isRequired)
        {
            Position = position;
            IsRequired = isRequired;
        }

        /// <summary>
        /// 位置
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 必填
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

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

    /// <summary>
    /// 数据元校验(长度、类型)
    /// </summary>
    public class MetaCodeAttribute : Attribute
    {
        public MetaCodeAttribute(int length, DataTypeEnum type)
        {
            Length = length;
            Type = type;
        }

        public enum DataTypeEnum
        {
            ANC = 0,
            AN = 1,
            N = 2,
            Amount = 3
        }

        /// <summary>
        /// 类型
        /// </summary>
        public DataTypeEnum Type { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 校验函数
        /// </summary>
        /// <param name="value">被校验对象</param>
        /// <returns>校验结果</returns>

        public bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var data = value == null ? string.Empty : value.ToString();

            if (!validLength(data))
            {
                return false;
            }


            if (!validType(data))
            {
                return false;
            }

            return true;
        }

        private bool validLength(string data)
        {
            if (data.Length != Length)
            {
                ErrorMessage = "长度验证未通过";

                return false;
            }

            return true;
        }

        private bool validType(string data)
        {
            var validTypeR = true;

            // 校验类型
            var dataChars = data.ToCharArray();

            if (Type == DataTypeEnum.N)
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
            else if (Type == DataTypeEnum.AN)
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
            else if (Type == DataTypeEnum.Amount)
            {
                validTypeR = new Regex(@"^-?\d+\.\d{2}$").IsMatch(data);

                ErrorMessage = "金额类型校验未通过！";
            }

            return validTypeR;
        }
    }
}
