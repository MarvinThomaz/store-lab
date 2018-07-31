using System;
using System.Collections.Generic;
using System.Linq;
using Store.Common.Enums;

namespace Store.Common.Contracts
{
    public class Errors : List<Info>
    {
        public bool IsValid => !this.Any();

        public bool ContainsType(InfoType type)
        {
            return this.Any(e => e.Code == (int)type);
        }
    }
}
