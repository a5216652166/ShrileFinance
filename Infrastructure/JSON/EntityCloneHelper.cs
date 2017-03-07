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
        /// <returns>克隆版实体</returns>
        public static T Clone<T>(T obj) where T : class
        {
            if (obj == default(T))
            {
                return default(T);
            }

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

            var jsonData = JsonConvert.SerializeObject(obj, jsonSerializerSettings);

            var newObj = JsonConvert.DeserializeObject<T>(jsonData, jsonSerializerSettings);

            return newObj;
        }
    }
}
