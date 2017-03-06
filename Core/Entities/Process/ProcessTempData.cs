namespace Core.Entities
{
    using System;
    using Interfaces;
    using Newtonsoft.Json;
    using Process;

    public class ProcessTempData : Entity, IAggregateRoot
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;

        public ProcessTempData() : base()
        {
            jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
        }

        public Guid InstanceId { get; set; }

        public string JsonData { get; set; }

        public virtual Instance Instance { get; set; }

        public T ConvertToObject<T>() where T : class
        {
            T obj = default(T);

            if (string.IsNullOrEmpty(JsonData) == false)
            {
                obj = JsonConvert.DeserializeObject<T>(JsonData, jsonSerializerSettings);
            }

            return obj;
        }

        public void ConvertToJsonData<T>(T obj) where T : class
        {
            if (obj != default(T))
            {
                JsonData = JsonConvert.SerializeObject(obj, jsonSerializerSettings);
            }

            JsonData = string.IsNullOrEmpty(JsonData) ? null : JsonData;
        }
    }
}
