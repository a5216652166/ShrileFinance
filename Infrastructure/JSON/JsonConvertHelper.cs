namespace Infrastructure.JSON
{
    using Newtonsoft.Json;

    public static class JsonConvertHelper
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

        /// <summary>
        /// json字符串转引用对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <param name="depth">深度</param>
        /// <returns>引用对象</returns>
        public static T Convert2Object<T>(string jsonStr, bool depth = false) where T : class
        {
            T obj = default(T);

            if (string.IsNullOrEmpty(jsonStr) == false)
            {
                if (depth)
                {
                    obj = JsonConvert.DeserializeObject<T>(jsonStr, JsonSerializerSettings);
                }
                else
                {
                    obj = JsonConvert.DeserializeObject<T>(jsonStr);
                }
            }

            return obj;
        }

        /// <summary>
        /// 引用对象转json字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">引用对象</param>
        /// <param name="depth">深度</param>
        /// <returns>json字符串</returns>
        public static string Convert2JsonStr<T>(T obj, bool depth = false) where T : class
        {
            var jsonStr = default(string);

            if (obj != default(T))
            {
                if (depth)
                {
                    jsonStr = JsonConvert.SerializeObject(obj, JsonSerializerSettings);
                }
                else
                {
                    jsonStr = JsonConvert.SerializeObject(obj);
                }
            }

            jsonStr = string.IsNullOrEmpty(jsonStr) ? null : jsonStr;

            return jsonStr;
        }
    }
}
