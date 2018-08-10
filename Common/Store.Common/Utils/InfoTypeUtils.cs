using System;
using System.Reflection;
using Store.Common.Attributes;
using Store.Common.Enums;
using Store.Common.Resources;

namespace Store.Common.Utils
{
    public static class InfoTypeUtils
    {
        public static string GetMessage(this InfoType type)
        {
            var enumType = type.GetType();
            var description = enumType.GetCustomAttribute<EnumDescription>();
            //var message = CommonResource.ResourceManager.GetString(description.Name);
            var message = type.ToString();

            return message;
        }
    }
}
