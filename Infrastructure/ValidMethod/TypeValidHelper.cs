namespace Infrastructure.ValidMethod
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 校验帮助类
    /// </summary>
    public static class TypeValidHelper
    {
        /// <summary>
        /// N类型
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否</returns>
        public static bool IsN(this string value)
        {
            value = value ?? string.Empty;

            var temp = value.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0X30 || temp[i] > 0X39)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// AN类型
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否</returns>
        public static bool IsAN(this string value)
        {
            value = value ?? string.Empty;

            var temp = value.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0X20 || temp[i] > 0X7E)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ANC类型
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否</returns>
        public static bool IsANC(this string value)
        {
            return true;
        }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否</returns>
        public static bool IsOrganizationCode(this string value)
        {
            value = value ?? string.Empty;

            // 基础校验（前8位为数字或者大写英文字母、后1位为校验码）
            var regResult = new Regex(@"^[A-Z0-9]{8}-[A-Z0-9]$").IsMatch(value);

            regResult |= new Regex(@"^[A-Z0-9]{8}[A-Z0-9]$").IsMatch(value);

            // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
            if (regResult)
            {
                value = value.Remove(value.IndexOf('-'), 1);

                var w = new int[] { 3, 7, 9, 10, 5, 8, 4, 2 };

                var c9 = 0;
                for (var index = 0; index < w.Length; index++)
                {
                    c9 += value[index].Mary36ToMary10() * w[index];
                }

                c9 = 11 - (c9 % 11);

                // 校验  当C9的值为10时，校验码应用大写的拉丁字母X表示；当C9的值为11时校验码用0表示。
                if (c9 == 10)
                {
                    regResult = value[8] == 'X';
                }
                else if (c9 == 11)
                {
                    regResult = value[8] == 0;
                }
                else
                {
                    // 三十六进制转十进制后进行校验
                    regResult = value[8].Mary36ToMary10() == c9;
                }
            }

            return regResult;
        }

        /// <summary>
        /// 贷款卡编码（中征码）
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否</returns>
        public static bool IsCreditCardCode(this string value)
        {
            value = value ?? string.Empty;

            // 基础校验（前3位为数字或者大写英文字母、后13位数字）
            var regResult = new Regex(@"^[A-Z0-9]{3}\d{13}$|^\d{16}$").IsMatch(value);

            // 后两位校验 前十四位乘以权重相加后除以97后的余数再加1后得到的数字
            if (regResult)
            {
                // 权重
                var w = new int[] { 1, 3, 5, 7, 11, 2, 13, 1, 1, 17, 19, 97, 23, 29 };

                // 后两位校验
                var lastValue = 0;
                for (var index = 0; index < w.Length; index++)
                {
                    // 十六进制转十进制后再进行计算
                    lastValue += w[index] * Convert.ToInt32(value[index].ToString(), 16);
                }

                lastValue = 1 + (lastValue % 97);

                var lastValueStr = lastValue > 10 ? lastValue.ToString() : "0" + lastValue;

                regResult = lastValueStr.Equals(value.Substring(14, 2));
            }

            return regResult;
        }

        /// <summary>
        /// 36进制转十进制
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否</returns>
        private static int Mary36ToMary10(this char value)
        {
            int num = 0;
            if (value >= 'A' && value <= 'Z')
            {
                num = value - 'A' + 10;
            }
            else if (value >= 'a' && value <= 'z')
            {
                num = value - 'a' + 36;
            }
            else
            {
                num = value - '0';
            }

            return num;
        }
    }
}
