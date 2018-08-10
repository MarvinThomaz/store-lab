using System;
namespace Store.Common.Attributes
{
    public class EnumDescription : Attribute
    {
        public EnumDescription(string resourceName)
        {
            Name = resourceName;
        }

        public string Name { get; set; }
    }
}
