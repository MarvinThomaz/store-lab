using Store.Common.Entities;
using Store.Common.Enums;
using Store.Common.Utils;
using System.Reflection;

namespace Store.Common.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static Info GetInfo(this PropertyInfo property, InfoType type)
        {
            return new Info
            {
                Property = property.Name,
                Code = (int)type,
                Message = type.GetMessage()
            };
        }
    }
}
