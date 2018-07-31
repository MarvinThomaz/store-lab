using System;
using System.Collections.Generic;
using Store.Common.Contracts;
using Store.Common.Enums;

namespace Store.Common.Exceptions
{
    public class EntityExcpetion : Exception
    {
        public EntityExcpetion(Errors errors)
        {
            Errors = errors;
        }

        public Errors Errors { get; set; }
    }
}
