﻿using System;
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

        public Task AddLaunchInProduct(string productKey, Launch launch, DateTime modifiedOn)
        {
            throw new NotImplementedException();
        }

        public Task AddOrUpdatePropertyInProduct(string productKey, string propertyName, string propertyValue, DateTime modifiedOn)
        {
            throw new NotImplementedException();
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

        public Task RemovePropertyFromProduct(string productKey, string propertyName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLaunchAvailableStatusInProduct(string productKey, string launchKey, bool isAvailable, DateTime modifiedOn)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePriceOfProduct(string productKey, Price price, DateTime modifiedOn)
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
