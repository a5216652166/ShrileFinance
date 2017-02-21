namespace Infrastructure.JSON
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    public static class JsonParseHelper
    {
        /// <summary>
        /// 将Json字符串解析为JObject对象
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>JObject对象</returns>
        public static JObject GetJObject(string jsonStr)
        {
            if (jsonStr == default(string))
            {
                return default(JObject);
            }

            var jObject = string.IsNullOrEmpty(jsonStr) ? default(JObject) : JObject.Parse(jsonStr);

            return jObject;
        }

        /// <summary>
        /// 将Json字符串解析为JObject对象
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <param name="name">属性名</param>
        /// <returns></returns>
        public static List<JProperty> GetJPropertites(string jsonStr, string name = null)
        {
            if (jsonStr == default(string))
            {
                return null;
            }

            var jObject = default(JObject);

            jObject = JObject.Parse(jsonStr);

            var jProperty = jObject.Properties();

            if (name == null)
            {
                jProperty = jProperty.Where(m => m.Name == name);
            }

            return jProperty.ToList();
        }
    }
}
