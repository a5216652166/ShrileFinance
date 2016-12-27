namespace Infrastructure.ValidMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public static KeyValuePair<bool, char> LulnMethod(this string value)
        {
            value = value ?? string.Empty;

            if (value.Length > 0 && new Regex(@"^[0-9]+$").IsMatch(value))
            {
                var sum = 0;

                var valueReverse = value.Reverse().ToArray();

                for (int i = 1; i < valueReverse.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += 2 * Convert.ToInt32(valueReverse[i]);
                    }
                    else
                    {
                        sum += Convert.ToInt32(valueReverse[i]);
                    }
                }

                return new KeyValuePair<bool, char>((sum * 9) % 10 == Convert.ToInt32(valueReverse[0]), Convert.ToChar((sum * 9) % 10));
            }

            return new KeyValuePair<bool, char>(false, 'e');
        }
    }
}
