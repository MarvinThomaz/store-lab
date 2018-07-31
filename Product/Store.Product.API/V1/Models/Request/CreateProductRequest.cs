using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Product.API.V1.Models.Request
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

        public List<CreatePropertyRequest> Properties { get; set; }
    }
}