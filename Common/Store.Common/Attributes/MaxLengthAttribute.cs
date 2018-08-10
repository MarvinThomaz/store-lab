using System;
using System.Reflection;
using Store.Common.Contracts;
using Store.Common.Enums;
using Store.Common.Extensions;
using Store.Common.Utils;

namespace Store.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int length)
        {
            Length = length;
        }

        public int Length { get; set; }

        public static void Validate(PropertyInfo property, object value, Errors errors)
        {
            var maxLength = property.GetCustomAttribute<MaxLengthAttribute>();

            if (maxLength != null)
            {
                var error = ValidateMaxLengthAttribute(property, value, maxLength, errors);

                if (error != null)
                    errors.Add(error);
            }
        }

        private static Info ValidateMaxLengthAttribute(PropertyInfo property, object value, MaxLengthAttribute maxLength, Errors errors)
        {
            if (!property.PropertyType.Equals(typeof(string)))
                throw new ArgumentException("Invalid Argument Type");

            var strValue = value as string;

            if (strValue?.Length > maxLength.Length)
            {
                return property.GetInfo(InfoType.MaxLengthObject);
            }

            return null;
        }

    }
}
