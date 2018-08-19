namespace Store.Product.Domain.EventArgs
{
    public class RemovePropertyFromProductEventArgs : System.EventArgs
    {
        public string PropertyName { get; set; }
        public string ProductKey { get; set; }
    }
}