namespace Store.Product.Domain.EventArgs
{
    public class UpdateProductNameEventArgs : System.EventArgs
    {
        public string Name { get; set; }
        public string ProductKey { get; set; }
    }
}