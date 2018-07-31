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

        public async Task UpdateProductAsync(Domain.Entities.Product product, string productKey)
        {
            if(productKey != null && product != null)
            {
                await _dataAccess.UpdateAsync(product, productKey);
            }
        }

        public async Task UpdateDeletedStatusOfProductAsync(string productKey, bool isDeleted, DateTime modifiedOn)
        {
            var properties = new Dictionary<string, object>
            {
                { nameof(Domain.Entities.Product.IsDeleted), isDeleted },
                { nameof(Domain.Entities.Product.ModifiedOn), modifiedOn }
            };

            await _dataAccess.UpdateAsync<Domain.Entities.Product>(productKey, properties);
        }

        public async Task UpdateNameOfProductAsync(string productKey, string name, DateTime modifiedOn)
        {
            var properties = new Dictionary<string, object>
            {
                { nameof(Domain.Entities.Product.Name), name },
                { nameof(Domain.Entities.Product.ModifiedOn), modifiedOn }
            };

            await _dataAccess.UpdateAsync<Domain.Entities.Product>(productKey, properties);
        }
    }
}
