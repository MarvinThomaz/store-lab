using Store.Common.Attributes;

namespace Store.Common.Enums
{
    public enum InfoType
    {
        [EnumDescription("Required property value.")]
        RequiredObject = 4220001,

        [EnumDescription("Invalid property length.")]
        MaxLengthObject = 4220002,

        [EnumDescription("Invalid property lentgh.")]
        MinLengthObject = 4220003,

        [EnumDescription("An object with this value exists.")]
        UniqueValidationObject = 422004,

        [EnumDescription("Property value cannot be null.")]
        NullableProperty = 422005,
    }
}
