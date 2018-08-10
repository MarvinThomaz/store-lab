using Store.Product.Domain.Entities;

namespace Store.Product.Domain.EventArgs
{
    public class AddOrUpdateProductPropertyEventArgs : System.EventArgs
    {
        public ProductProperty Property { get; set; }
        public string ProductKey { get; set; }
    }
}