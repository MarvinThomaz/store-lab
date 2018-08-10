using Store.Common.Infra;
using Store.Common.List;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddLaunchInProductAsync(string productKey, Launch launch, DateTime modifiedOn)
        {
            var product = await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(productKey);

            product.Launches.Add(launch);
            product.ModifiedOn = modifiedOn;

            await _dataAccess.UpdateAsync(product, productKey);
        }

        public async Task AddPropertyInProductAsync(string productKey, ProductProperty property, DateTime modifiedOn)
        {
            var product = await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(productKey);

            product.Properties.Add(property);
            product.ModifiedOn = modifiedOn;

            await _dataAccess.UpdateAsync(product, productKey);
        }

        public async Task UpdatePropertyInProductAsync(string productKey, ProductProperty property, DateTime modifiedOn)
        {
            var product = await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(productKey);

            product.Properties.ForEach(p =>
            {
                if (p.Name == property.Name)
                    p = property;
            });

            product.ModifiedOn = modifiedOn;

            await _dataAccess.UpdateAsync(product, productKey);
        }

        public async Task CreateProductAsync(Domain.Entities.Product product)
        {
            await _dataAccess.InsertAsync(product);
        }

        public async Task<IPagingList<Domain.Entities.Product>> GetAllProductsAsync(int page, int recordsPerPage)
        {
            return await _dataAccess.SelectAsync<Domain.Entities.Product>(page, recordsPerPage);
        }

        public async Task<Domain.Entities.Product> GetProductByKeyAsync(string key)
        {
            return await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(key);
        }

        public async Task RemovePropertyFromProductAsync(string productKey, string propertyName, DateTime modifiedOn)
        {
            var product = await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(productKey);

            product.Properties.RemoveAll(p => p.Name == propertyName);
            product.ModifiedOn = modifiedOn;

            await _dataAccess.UpdateAsync(product, productKey);

        }

        public async Task UpdateEnableProductStatusAsync(string productKey, bool isEnabled, DateTime modifiedOn)
        {
            var properties = new Dictionary<string, object>
            {
                { "IsEnabled", isEnabled },
                { "ModifiedOn", modifiedOn }
            };

            await _dataAccess.UpdateAsync<Domain.Entities.Product>(properties, productKey);
        }

        public async Task UpdateLaunchAvailableStatusInProductAsync(string productKey, string launchKey, bool isAvailable, DateTime modifiedOn)
        {
            var product = await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(productKey);

            product.Launches.ForEach(l =>
            {
                if (l.Key == launchKey)
                    l.IsAvailable = isAvailable;
            });

            product.ModifiedOn = modifiedOn;

            await _dataAccess.UpdateAsync(product, productKey);
        }

        public async Task UpdatePriceOfProductAsync(string productKey, Price price, DateTime modifiedOn)
        {
            var properties = new Dictionary<string, object>
            {
                { "Price", price },
                { "ModifiedOn", modifiedOn }
            };

            await _dataAccess.UpdateAsync<Domain.Entities.Product>(properties, productKey);
        }

        public async Task UpdateProductAsync(Domain.Entities.Product product, string productKey)
        {
            await _dataAccess.UpdateAsync(product, productKey);
        }
    }
}
