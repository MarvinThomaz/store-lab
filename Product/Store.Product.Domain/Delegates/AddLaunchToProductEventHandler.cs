using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void AddLaunchToProductEventHandler(object sender, AddLaunchToProductEventArgs args);
}