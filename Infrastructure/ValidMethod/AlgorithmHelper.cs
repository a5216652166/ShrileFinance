namespace Infrastructure.ValidMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 算法帮助类
    /// </summary>
    public static class AlgorithmHelper
    {
        /// <summary>
        /// Luhn算法
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>是/否、正确值</returns>
        public static KeyValuePair<bool, int> LulnMethod(this string value)
        {
            value = value ?? string.Empty;

            if (value.Length > 0 && new Regex(@"^[0-9]+$").IsMatch(value))
            {
                var sum = 0;
                var temp = 0;

                var valueReverse = value.Reverse().ToArray();

                for (int i = 1; i < valueReverse.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        temp = 2 * Convert.ToInt32(valueReverse[i].ToString());

                        temp = temp > 9 ? temp - 9 : temp;
                    }
                    else
                    {
                        temp = Convert.ToInt32(valueReverse[i].ToString());
                    }

                    sum += temp;
                }

                return new KeyValuePair<bool, int>((sum * 9) % 10 == Convert.ToInt32(valueReverse[0].ToString()), (sum * 9) % 10);
            }

            return new KeyValuePair<bool, int>(false, -1);
        }

        /// <summary>
        /// MD5加密（16位）
        /// </summary>
        /// <param name="inputValue">输入字符串</param>
        /// <returns>加密结果</returns>
        public static string MD5Encrypt_16bit(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                throw new ArgumentException("输入字符串有误！");
            }

            var inputBytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(inputValue));

            var outputVaue = BitConverter.ToString(inputBytes, 4, 8).Replace("-", string.Empty);

            return outputVaue;
        }

        /// <summary>
        /// MD5加密（32位）
        /// </summary>
        /// <param name="inputValue">输入字符串</param>
        /// <returns>加密结果</returns>
        public static string MD5Encrypt_32bit(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                throw new ArgumentException("输入字符串有误！");
            }

            var inputBytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(inputValue));

            var outputVaue = BitConverter.ToString(inputBytes).Replace("-", string.Empty);

            return outputVaue;
        }
    }
}
