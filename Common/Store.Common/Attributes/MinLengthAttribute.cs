using System;
using System.Reflection;
using Store.Common.Contracts;
using Store.Common.Enums;
using Store.Common.Extensions;
using Store.Common.Utils;

namespace Store.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MinLengthAttribute : Attribute
    {
        public MinLengthAttribute(int length)
        {
            Length = length;
        }

        public int Length { get; set; }

        public static void Validate(PropertyInfo property, object value, Errors errors)
        {
            var minLength = property.GetCustomAttribute<MinLengthAttribute>();

            if (minLength != null)
            {
                var error = ValidateMinLengthAttribute(property, value, minLength, errors);

                if (error != null)
                    errors.Add(error);
            }
        }

        private static Info ValidateMinLengthAttribute(PropertyInfo property, object value, MinLengthAttribute minLength, Errors errors)
        {
            if (!property.PropertyType.Equals(typeof(string)))
                throw new ArgumentException("Invalid Argument Type");

            var strValue = value as string;

            if (strValue?.Length < minLength.Length)
            {
                return property.GetInfo(InfoType.MinLengthObject);
            }

            return null;
        }
    }
}
