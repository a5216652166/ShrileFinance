﻿namespace Core.Entities
{
    using System;
    using Flow;
    using Interfaces;
    using Newtonsoft.Json;

    public class ProcessTempData : Entity, IAggregateRoot
    {
        public Guid InstanceId { get; set; }

        public string JsonData { get; set; } = string.Empty;

        public virtual Instance Instance { get; set; }

        public T ConvertToObject<T>() where T : class
        {
            T obj = default(T);

            if (string.IsNullOrEmpty(JsonData) == false)
            {
                obj= (T)JsonConvert.DeserializeObject(JsonData, typeof(T));
            }

            return obj;
        }

        public void ConvertToJsonData<T>(T obj) where T : class
        {
            if (obj != default(T))
            {
                JsonData = JsonConvert.SerializeObject(obj);
            }
        }
    }
}