﻿using Store.Common.Entities;
using Store.Common.Enums;
using Store.Common.Extensions;
using System;
using System.Reflection;

namespace Store.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MaxLengthAttribute : System.ComponentModel.DataAnnotations.MaxLengthAttribute
    {
        public MaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = InfoType.MaxLengthObject.ToString();
        }

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
