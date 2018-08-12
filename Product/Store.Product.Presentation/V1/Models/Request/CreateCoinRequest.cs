using System.ComponentModel.DataAnnotations;

namespace Store.Product.Presentation.V1.Models.Request
{
    public class CreateCoinRequest
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string Reference { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Country { get; set; }
    }
}