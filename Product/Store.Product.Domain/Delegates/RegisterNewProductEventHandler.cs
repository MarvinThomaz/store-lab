using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void RegisterNewProductEventHandler(object sender, RegisterNewProductEventArgs args);
}