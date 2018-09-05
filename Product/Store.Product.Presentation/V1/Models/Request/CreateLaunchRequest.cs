using Store.Product.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Product.Presentation.V1.Models.Request
{
    public class CreateLaunchRequest
    {
        [Required]
        public LaunchEnum Type { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public ValueTypeEnum ValueType { get; set; }

        public CreateCoinRequest Coin { get; set; }
    }
}