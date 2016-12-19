namespace Core.Entities.Message
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTypeAttribute : Attribute
    {
        public ValidTypeAttribute(int dataLength, int dataLocation, string errorMessage, DataTypeEnum dataType)
        {
            DataLength = dataLength;
            DataLocation = dataLocation;
            ErrorMessage = errorMessage;
            DataType = dataType;
        }

        public enum DataTypeEnum
        {
            ANC = 0,
            AN = 1,
            N = 2,
            Amount = 3
        }

        public DataTypeEnum DataType { get; set; }

        public int DataLength { get; set; }

        public int DataLocation { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsValid(object value)
        {
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

            // 校验长度
            validTypeR = data.Length == DataLength;

            if (!validTypeR)
            {
                return false;
            }

            return validTypeR;
        }
    }
}
