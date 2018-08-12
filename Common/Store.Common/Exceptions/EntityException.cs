using Store.Common.Entities;
using System;

namespace Store.Common.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(Errors errors)
        {
            Errors = errors;
        }

        public EntityException(params Info[] errors)
        {
            Errors = new Errors();

            Errors.AddRange(errors);
        }

        public Errors Errors { get; set; }
    }
}
