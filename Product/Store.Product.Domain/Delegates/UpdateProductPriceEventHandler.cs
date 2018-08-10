using Store.Product.Domain.EventArgs;

namespace Store.Product.Domain.Delegates
{
    public delegate void UpdateProductPriceEventHandler(object sender, UpdateProductPriceEventArgs args);
}