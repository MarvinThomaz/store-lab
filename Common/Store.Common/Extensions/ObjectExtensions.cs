using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Store.Common.Attributes;
using Store.Common.Contracts;

namespace Store.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNumericType(this object obj)
        {
            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static Errors Validate(this object entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();
            var errors = new Errors();

            foreach (var property in properties)
            {
                var propertyErrors = ValidateAllProperties(property, entity);

                errors.AddRange(propertyErrors);
            }

            return errors;
        }

        private static Errors ValidateAllProperties(PropertyInfo property, object entity)
        {
            var value = property.GetValue(entity);

            if (value is IEnumerable)
            {
                var errors = ValidateProperty(property, entity, value);
                var list = value as IEnumerable;

                foreach (var item in list)
                {
                    var itemErrors = Validate(item);

                    errors.AddRange(itemErrors);
                }

                return errors;
            }
            else
            {
                return ValidateProperty(property, entity, value);
            }
        }

        private static Errors ValidateProperty(PropertyInfo property, object entity, object value)
        {
            var errors = new Errors();

            RequiredAttribute.Validate(property, value, errors);
            MaxLengthAttribute.Validate(property, value, errors);
            MinLengthAttribute.Validate(property, value, errors);

            return errors;
        }
    }
}
