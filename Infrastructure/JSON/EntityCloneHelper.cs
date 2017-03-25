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
        public static T Clone<T>(T obj, bool depth = false) where T : class
        {
            if (obj == default(T))
            {
                return default(T);
            }

            var setting = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.None,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
            };

            if (depth)
            {
                setting.TypeNameHandling = TypeNameHandling.Auto;
            }

            var jsonData = JsonConvert.SerializeObject(obj, setting);

            var newObj = default(T);

            try
            {
                newObj = JsonConvert.DeserializeObject<T>(jsonData, setting);
            }
            catch
            {
            }

            return newObj;
        }
    }
}
