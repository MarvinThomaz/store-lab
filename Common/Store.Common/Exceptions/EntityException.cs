using Store.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Common.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(Errors errors)
        {
            Errors = errors;
        }

        public EntityException(IEnumerable<Info> errors) : this(errors.ToArray()) { }

        public EntityException(params Info[] errors)
        {
            Errors = new Errors();

            Errors.AddRange(errors);
        }

        public Errors Errors { get; set; }
    }
}
