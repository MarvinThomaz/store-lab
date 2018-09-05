using Store.Common.Entities;
using Store.Common.Interfaces;
using Store.Product.Domain.Delegates;
using Store.Product.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Product.Domain.Services
{
    public interface IProductApplicationService
    {
        event AddLaunchToProductEventHandler LaunchAddedToProduct;
        event AddOrUpdateProductPropertyEventHandler PropertyAddedOrUpdatedInProduct;
        event DisableProductEventHandler ProductDisabled;
        event RegisterNewProductEventHandler ProductRegisted;
        event RemovePropertyFromProductEventHandler ProductPropertyRemoved;
        event UnavailableProductLaunchEventHandler ProductLaunchUnavailable;
        event UpdateProductNameEventHandler ProductNameUpdated;
        event UpdateProductPriceEventHandler ProductPriceUpdated;

        Task RegisterNewProductAsync(Entities.Product product, List<RequestFile> photos, RequestFile profile);
        Task AddOrUpdateProductPropertyAsync(ProductProperty property, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string productKey);
        Task<IPagingList<Entities.Product>> GetProductsAsync(int page, int recordsPerPage);
        Task UpdateProductNameAsync(string name, string productKey);
        Task RemovePropertyFromProductAsync(string propertyKey, string productKey);
        Task DisableProductAsync(string productKey);
        Task UpdateProductPriceAsync(string productKey, Price price);
        Task AddLaunchToProductAsync(string productKey, Launch launch);
        Task UnavailableProductLaunchAsync(string productKey, string launchKey);
    }
}