using System.ComponentModel.DataAnnotations;

namespace Store.Product.API.V1.Models.Request
{
    public class UpdateProductRequest
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}