using Store.Product.Domain.Entities;

namespace Store.Product.Domain.EventArgs
{
    public class UpdateProductPriceEventArgs : System.EventArgs
    {
        public string ProductKey { get; set; }
        public Price Price { get; set; }
    }
}