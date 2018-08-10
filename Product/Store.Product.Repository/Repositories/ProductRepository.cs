using Store.Common.Infra;
using Store.Common.List;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Repositories;
using System;
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

        public Task RemovePropertyFromProductAsync(string productKey, string propertyName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEnableProductStatusAsync(string productKey, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLaunchAvailableStatusInProductAsync(string productKey, string launchKey, bool isAvailable, DateTime modifiedOn)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePriceOfProductAsync(string productKey, Price price, DateTime modifiedOn)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(Domain.Entities.Product product, string productKey)
        {
            if(productKey != null && product != null)
            {
                await _dataAccess.UpdateAsync(product, productKey);
            }
        }
    }
}
