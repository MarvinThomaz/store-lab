using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Common.Infra;
using Store.Common.List;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Repositories;

namespace Store.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddOrUpdatePropertyAsync(Property property, string productKey)
        {
            var product = await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(productKey);
            
            if(product.Properties == null)
            {
                product.Properties = new List<Property>();
            }

            if(product.Properties?.Any(p => p.Name == property.Name) == true)
            {
                var persistedProperty = product.Properties.FirstOrDefault(p => p.Name == property.Name);

                persistedProperty.Value = property.Value;
            }
            else
            {
                product.Properties.Add(property);
            }

            await _dataAccess.UpdateAsync(product, product.Key);
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
            if(key == null)
            {
                return null;
            }

            return await _dataAccess.SelectByKeyAsync<Domain.Entities.Product>(key);
        }

        public async Task RemovePropertyAsync(string propertyKey, string productKey)
        {
            if(propertyKey != null && productKey != null)
            {
                var product = await _dataAccess.SelectByQueryAsync<Domain.Entities.Product>(c => c.Key == productKey && c.Properties.Select(p => p.Name).Contains(propertyKey));

                if(product != null)
                {
                    var property = product.Properties.FirstOrDefault(p => p.Name == propertyKey);

                    product.Properties.Remove(property);

                    await _dataAccess.UpdateAsync(product, productKey);
                }
            }
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
