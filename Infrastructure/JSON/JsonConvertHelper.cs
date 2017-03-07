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
        /// <returns>引用对象</returns>
        public static T Convert2Object<T>(string jsonStr) where T : class
        {
            T obj = default(T);

            if (string.IsNullOrEmpty(jsonStr) == false)
            {
                obj = JsonConvert.DeserializeObject<T>(jsonStr, JsonSerializerSettings);
            }

            return obj;
        }

        /// <summary>
        /// 引用对象转json字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">引用对象</param>
        /// <returns>json字符串</returns>
        public static string Convert2JsonStr<T>(T obj) where T : class
        {
            var jsonStr = default(string);

            if (obj != default(T))
            {
                jsonStr = JsonConvert.SerializeObject(obj, JsonSerializerSettings);
            }

            jsonStr = string.IsNullOrEmpty(jsonStr) ? null : jsonStr;

            return jsonStr;
        }
    }
}
