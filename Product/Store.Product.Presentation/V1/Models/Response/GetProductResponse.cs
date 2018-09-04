using System;
using System.Collections.Generic;
using Store.Product.Domain.Entities;

namespace Store.Product.Presentation.V1.Models.Response
{
    public class GetProductResponse
    {
        public string Key { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<ProductProperty> Properties { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
