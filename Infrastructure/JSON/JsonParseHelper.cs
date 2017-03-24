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
            if (jsonStr == default(string) || JsonCheck(jsonStr) == false)
            {
                return default(JObject);
            }

            var jsonObj = JObject.Parse(jsonStr);

            return jsonObj;
        }

        public static IEnumerable<JProperty> GetJProperties(string jsonStr)
        {
            if (jsonStr == default(string) || JsonCheck(jsonStr) == false)
            {
                return null;
            }

            var jsonProperties = JObject.Parse(jsonStr).Properties();

            return jsonProperties;
        }

        /// <summary>
        /// 解析Json字符串中的指定属性
        /// </summary>
        /// <param name="jsonStr">json字符串</param>
        /// <param name="name">属性名</param>
        /// <param name="layerNumber">子节点层数</param>
        /// <returns></returns>
        public static IEnumerable<JToken> GetJProperty(string jsonStr, string name, int layerNumber = 1)
        {
            if (jsonStr == default(string) || JsonCheck(jsonStr) == false)
            {
                return null;
            }

            var jsonTokenList = JObject.Parse(jsonStr).Property(name).AsEnumerable();

            for (var i = 1; i < layerNumber; i++)
            {
                jsonTokenList = jsonTokenList.Children().AsEnumerable();
            }

            return jsonTokenList;
        }

        private static bool JsonCheck(string jsonStr)
        {
            var isJson = true;

            try
            {
                JObject.Parse(jsonStr);
            }
            catch
            {
                isJson = false;
            }

            return isJson;
        }
    }
}
