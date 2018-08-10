using MongoDB.Bson.Serialization.Attributes;
using Store.Common.Attributes;
using Store.Common.Entities;
using System.Collections.Generic;

namespace Store.Product.Domain.Entities
{
    public class Group : BaseEntity
    {
        [BsonId]
        [Required]
        [MaxLength(36)]
        [MinLength(36)]
        public string Key { get; set; }

        [Required]
        public Price Price { get; set; }

        [Required]
        public List<Launch> Launches { get; set; }
    }
}
