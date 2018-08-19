using MongoDB.Bson.Serialization.Attributes;
using Store.Common.Attributes;
using Store.Common.Entities;

namespace Store.Product.Domain.Entities
{
    public class Price : BaseEntity
    {
        [BsonId]
        [Required]
        [MinLength(36)]
        [MaxLength(36)]
        public string Key { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public Coin Coin { get; set; }
    }
}
