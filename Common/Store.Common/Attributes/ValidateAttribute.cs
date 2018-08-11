using Store.Common.Contracts;
using System;
using System.Reflection;

namespace Store.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ValidateAttribute : Attribute
    {
        public ValidateAttribute(bool required, int maxLength = 0, int minLength = 0)
        {
            Required = required;
            MaxLength = maxLength;
            MinLength = minLength;
        }

        public bool Required { get; }
        public int MaxLength { get; }
        public int MinLength { get; }

        public static void Validate(PropertyInfo property, object value, Errors errors)
        {
            var validate = property.GetCustomAttribute<ValidateAttribute>();

            if (validate != null)
            {
                ValidateAttributeValidation(validate, value, property, errors);
            }
        }

        private static void ValidateAttributeValidation(ValidateAttribute attribute, object value, PropertyInfo property, Errors errors)
        {
            if (attribute.Required)
                RequiredAttribute.Validate(property, value, errors);

            if (attribute.MinLength > 0)
                MinLengthAttribute.Validate(property, value, errors);

            if (attribute.MaxLength > 0)
                MaxLengthAttribute.Validate(property, value, errors);
        }
    }
}