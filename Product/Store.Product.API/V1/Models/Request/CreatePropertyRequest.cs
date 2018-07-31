using System.ComponentModel.DataAnnotations;

namespace Store.Product.API.V1.Models.Request
{
    public class CreatePropertyRequest
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Value { get; set; }
    }
}