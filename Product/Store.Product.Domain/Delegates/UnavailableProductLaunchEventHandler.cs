using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void UnavailableProductLaunchEventHandler(object sender, UnavailableProductLaunchEventArgs args);
}