using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Common.Entities;
using Store.Common.Enums;
using Store.Common.Exceptions;
using System;
using System.Linq;

namespace Store.Common.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static void Validate(this ModelStateDictionary modelState)
        {
            var errors = new Errors();

            var modelErrors = modelState.SelectMany(m => m.Value.Errors.Select(e => new { Property = m.Key, Message = e.ErrorMessage }));

            foreach (var error in modelErrors)
            {
                InfoType type = InfoType.Undefined;

                Enum.TryParse(error.Message, out type);

                errors.AddError(type, error.Property);
            }

            if (errors?.Any() == true)
                throw new EntityException(errors);
        }
    }
}
