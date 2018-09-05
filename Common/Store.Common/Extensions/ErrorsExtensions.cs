using Store.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Store.Common.Extensions
{
    public static class ErrorsExtensions
    {
        public static bool IsValid(this IEnumerable<Info> errors)
        {
            return errors?.Any() != true;
        }
    }
}