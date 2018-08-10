using MongoDB.Bson.Serialization.Attributes;
using Store.Common.Attributes;
using Store.Common.Entities;
using Store.Product.Domain.Enums;

namespace Store.Product.Domain.Entities
{
    public class Launch : BaseEntity
    {
        [BsonId]
        [Required]
        [MaxLength(36)]
        [MinLength(36)]
        public string Key { get; set; }

        [Required]
        public LaunchEnum Type { get; set; }
        
        [Required]
        public decimal Value { get; set; }
    }
}