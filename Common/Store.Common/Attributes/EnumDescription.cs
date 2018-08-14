using System;
namespace Store.Common.Attributes
{
    public class EnumDescription : Attribute
    {
        public EnumDescription(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
