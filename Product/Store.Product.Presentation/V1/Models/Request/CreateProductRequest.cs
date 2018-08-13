using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Product.Presentation.V1.Models.Request
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(128)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public CreatePriceRequest Price { get; set; }

        [Required]
        public byte[] ProfilePhoto { get; set; }

        public List<byte[]> Photos { get; set; }
        public List<CreatePropertyRequest> Properties { get; set; }
        public List<CreateLaunchRequest> Launches { get; set; }
    }
}