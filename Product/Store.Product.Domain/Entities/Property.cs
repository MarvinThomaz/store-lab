using Store.Common.Attributes;

namespace Store.Product.Domain.Entities
{
    public class Property
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }
    }
}
