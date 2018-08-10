namespace Store.Product.Domain.EventArgs
{
    public class UnavailableProductLaunchEventArgs : System.EventArgs
    {
        public string ProductKey { get; set; }
        public string LaunchKey { get; set; }
    }
}