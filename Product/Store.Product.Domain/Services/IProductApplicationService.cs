﻿using Store.Common.List;
using Store.Product.Domain.Delegates;
using Store.Product.Domain.Entities;
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
        event UpdateProductEventHandler ProductUpdated;
        event UpdateProductPriceEventHandler ProductPriceUpdated;

        Task RegisterNewProductAsync(Entities.Product product);
        Task AddOrUpdateProductPropertyAsync(ProductProperty property, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string productKey);
        Task<IPagingList<Entities.Product>> GetProductsAsync(int page, int recordsPerPage);
        Task UpdateProductAsync(Entities.Product product, string productKey);
        Task RemovePropertyFromProductAsync(string propertyKey, string productKey);
        Task DisableProductAsync(string productKey);
        Task UpdateProductPriceAsync(string productKey, Price price);
        Task AddLaunchToProductAsync(string productKey, Launch launch);
        Task UnavailableProductLaunchAsync(string productKey, string launchKey);
    }
}