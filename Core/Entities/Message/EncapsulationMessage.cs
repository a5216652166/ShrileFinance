using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Message
{
    public class EncapsulationMessage
    {
        public static string DisplaySelfAttribute<T>() where T : class, new()
        {
            Type objType = typeof(T);

            // 获取类属性上自定义的特效
            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                //获取order属性
                //var orderAttrs = propInfo.GetCustomAttributes(typeof(),true);
            }

            return String.Empty;
        }
    }
}
