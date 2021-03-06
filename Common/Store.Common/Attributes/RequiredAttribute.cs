﻿using Store.Common.Entities;
using Store.Common.Enums;
using Store.Common.Extensions;
using System;
using System.Reflection;

namespace Store.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute()
        {
            ErrorMessage = InfoType.RequiredObject.ToString();
        }

        public static void Validate(PropertyInfo property, object value, Errors errors)
        {
            var required = property.GetCustomAttribute<RequiredAttribute>();

            if (required != null)
            {
                var error = ValidateRequiredAttribute(value, property, errors);

                if (error != null)
                    errors.Add(error);
            }
        }

        private static Info ValidateRequiredAttribute(object value, PropertyInfo property, Errors errors)
        {
            if (value == null || (value is string && string.IsNullOrEmpty(value as string)) || ((value.IsNumericType() && value.Equals(0))))
            {
                var info = property.GetInfo(InfoType.RequiredObject);

                errors.Add(info);
            }

            return null;
        }
    }
}
