using Store.Common.Attributes;
using Store.Common.Enums;
using System.Reflection;

namespace Store.Common.Utils
{
    public static class InfoTypeUtils
    {
        public static string GetMessage(this InfoType type)
        {
            var enumType = type.GetType();
            var description = enumType.GetCustomAttribute<EnumDescription>();

            return description.Name;
        }
    }
}
