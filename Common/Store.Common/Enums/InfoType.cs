using System;
using Store.Common.Attributes;
using Store.Common.Resources;

namespace Store.Common.Enums
{
    public enum InfoType
    {
        [EnumDescription("RequiredProperty")]
        RequiredObject = 4220001,

        [EnumDescription("MaxLengthProperty")]
        MaxLengthObject = 4220002,

        [EnumDescription("MinLengthObject")]
        MinLengthObject = 4220003,

        [EnumDescription("MinLengthObject")]
        UniqueValidationObject = 422004,
    }
}
