namespace Store.Product.Domain.EventArgs
{
    public class DisableProductEventArgs : System.EventArgs
    {
        public string ProductKey { get; set; }
    }
}
