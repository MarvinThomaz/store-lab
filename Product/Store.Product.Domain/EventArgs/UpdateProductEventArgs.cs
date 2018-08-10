namespace Store.Product.Domain.EventArgs
{
    public class UpdateProductEventArgs : System.EventArgs
    {
        public Entities.Product Product { get; set; }
        public string ProductKey { get; set; }
    }
}