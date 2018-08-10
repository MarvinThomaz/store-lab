namespace Store.Product.Domain.EventArgs
{
    public class RemovePropertyFromProductEventArgs : System.EventArgs
    {
        public string PropertyKey { get; set; }
        public string ProductKey { get; set; }
    }
}