using Store.Common.Interfaces;
using Store.Product.Domain.Delegates;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Product.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        public event AddLaunchToProductEventHandler LaunchAddedToProduct;
        public event AddOrUpdateProductPropertyEventHandler PropertyAddedOrUpdatedInProduct;
        public event DisableProductEventHandler ProductDisabled;
        public event RegisterNewProductEventHandler ProductRegisted;
        public event RemovePropertyFromProductEventHandler ProductPropertyRemoved;
        public event UnavailableProductLaunchEventHandler ProductLaunchUnavailable;
        public event UpdateProductNameEventHandler ProductNameUpdated;
        public event UpdateProductPriceEventHandler ProductPriceUpdated;

        public Task AddLaunchToProductAsync(string productKey, Launch launch)
        {
            throw new NotImplementedException();
        }

        public Task AddOrUpdateProductPropertyAsync(ProductProperty property, string productKey)
        {
            throw new NotImplementedException();
        }

        public Task DisableProductAsync(string productKey)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Product> GetProductByKeyAsync(string productKey)
        {
            throw new NotImplementedException();
        }

        public Task<IPagingList<Domain.Entities.Product>> GetProductsAsync(int page, int recordsPerPage)
        {
            throw new NotImplementedException();
        }

        public Task RegisterNewProductAsync(Domain.Entities.Product product, IEnumerable<byte[]> photos, byte[] profile)
        {
            throw new NotImplementedException();
        }

        public Task RemovePropertyFromProductAsync(string propertyKey, string productKey)
        {
            throw new NotImplementedException();
        }

        public Task UnavailableProductLaunchAsync(string productKey, string launchKey)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductNameAsync(string name, string productKey)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductPriceAsync(string productKey, Price price)
        {
            throw new NotImplementedException();
        }
    }
}