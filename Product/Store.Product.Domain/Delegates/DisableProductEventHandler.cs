using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void DisableProductEventHandler(object sender, DisableProductEventArgs args);
}