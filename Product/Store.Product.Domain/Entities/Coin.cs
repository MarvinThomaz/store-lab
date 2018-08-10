using MongoDB.Bson.Serialization.Attributes;
using Store.Common.Attributes;
using Store.Common.Entities;

namespace Store.Product.Domain.Entities
{
    public class Coin : BaseEntity
    {
        [BsonId]
        [Required]
        [MinLength(36)]
        [MaxLength(36)]
        public string Key { get; set; }

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