namespace Infrastructure.JSON
{
    using Newtonsoft.Json;

    public static class JsonConvertHelper
    {
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
                obj = (T)JsonConvert.DeserializeObject(jsonStr, typeof(T));
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
                jsonStr = JsonConvert.SerializeObject(obj);
            }

            jsonStr = string.IsNullOrEmpty(jsonStr) ? null : jsonStr;

            return jsonStr;
        }
    }
}
