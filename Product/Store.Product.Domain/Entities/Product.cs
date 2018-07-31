using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Store.Common.Attributes;
using Store.Common.Entities;

namespace Store.Product.Domain.Entities
{
    public class Product : BaseEntity
    {
        [BsonId]
        [Required]
        [MaxLength(36)]
        [MinLength(36)]
        public string Key { get; set; }

        [Required]
        [MaxLength(128)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        public List<Property> Properties { get; set; }
    }
}
