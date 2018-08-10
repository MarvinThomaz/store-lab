namespace Store.Product.Domain.EventArgs
{
    public class RegisterNewProductEventArgs : System.EventArgs
    {
        public Entities.Product Product { get; set; }
    }
}