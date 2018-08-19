using Store.Product.Domain.Entities;

namespace Store.Product.Domain.EventArgs
{
    public class AddLaunchToProductEventArgs : System.EventArgs
    {
        public string ProductKey { get; set; }
        public Launch Launch { get; set; }
    }
}