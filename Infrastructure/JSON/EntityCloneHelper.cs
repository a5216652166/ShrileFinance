namespace Infrastructure.JSON
{
    using Newtonsoft.Json;

    public static class EntityCloneHelper
    {
        /// <summary>
        /// 实体克隆
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">实体对象</param>
        /// <param name="depth">深度</param>
        /// <returns>克隆版实体</returns>
        public static T Clone<T>(T obj, bool depth = false) where T : class
        {
            if (obj == default(T))
            {
                return default(T);
            }

            var jsonData = default(string);

            var newObj = default(T);

            if (depth)
            {
                var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

                jsonData = JsonConvert.SerializeObject(obj, jsonSerializerSettings);

                newObj = JsonConvert.DeserializeObject<T>(jsonData, jsonSerializerSettings);
            }
            else {
                jsonData = JsonConvert.SerializeObject(obj);

                newObj = JsonConvert.DeserializeObject<T>(jsonData);
            }

            return newObj;
        }
    }
}
