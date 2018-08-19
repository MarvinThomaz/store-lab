using MongoDB.Bson.Serialization.Attributes;
using Store.Common.Attributes;
using Store.Common.Entities;
using System.Collections.Generic;

namespace Store.Product.Domain.Entities
{
    public class ProductGroup : BaseEntity
    {
        [BsonId]
        [Required]
        [MaxLength(36)]
        [MinLength(36)]
        public string Key { get; set; }

        [Required]
        public Price Price { get; set; }

        [Required]
        public string ProfilePhoto { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public List<Product> Products { get; set; }
        public List<Launch> Launches { get; set; }
    }
}
