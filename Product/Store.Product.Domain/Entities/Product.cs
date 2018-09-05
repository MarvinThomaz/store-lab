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

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public Price Price { get; set; }

        [Required]
        public ResponseFile ProfilePhoto { get; set; }

        public List<ResponseFile> Photos { get; set; }
        public List<ProductProperty> Properties { get; set; }
        public List<Launch> Launches { get; set; }
    }
}
