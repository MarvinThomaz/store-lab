using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void AddOrUpdateProductPropertyEventHandler(object sender, AddOrUpdateProductPropertyEventArgs args);
}