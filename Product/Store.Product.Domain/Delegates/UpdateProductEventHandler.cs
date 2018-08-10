using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void UpdateProductEventHandler(object sender, UpdateProductEventArgs args);
}
