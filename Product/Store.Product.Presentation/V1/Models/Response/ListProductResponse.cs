using System;

namespace Store.Product.Presentation.V1.Models.Response
{
    public class ListProductResponse
    {
        public string Key { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
