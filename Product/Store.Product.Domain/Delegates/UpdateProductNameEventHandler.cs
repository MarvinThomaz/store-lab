using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void UpdateProductNameEventHandler(object sender, UpdateProductNameEventArgs args);
}
