using Store.Common.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Store.Common.Entities
{
    public class Errors : List<Info>
    {
        public bool IsValid => !this.Any();

        public void AddError(InfoType type, string property)
        {
            Add(new Info(type, property));
        }

        public bool ContainsType(InfoType type)
        {
            return this.Any(e => e.Code == (int)type);
        }
    }
}
