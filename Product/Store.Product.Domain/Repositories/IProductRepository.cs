﻿using System;
using System.Threading.Tasks;
using Store.Common.List;
using Store.Product.Domain.Entities;

namespace Store.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Entities.Product product);
        Task UpdateProductAsync(Entities.Product product, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string productKey);
        Task<IPagingList<Entities.Product>> GetAllProductsAsync(int page, int recordsPerPage);
        Task AddOrUpdatePropertyInProductAsync(string productKey, string propertyName, string propertyValue, DateTime modifiedOn);
        Task RemovePropertyFromProductAsync(string productKey, string propertyName);
        Task UpdatePriceOfProductAsync(string productKey, Price price, DateTime modifiedOn);
        Task AddLaunchInProductAsync(string productKey, Launch launch, DateTime modifiedOn);
        Task UpdateLaunchAvailableStatusInProductAsync(string productKey, string launchKey, bool isAvailable, DateTime modifiedOn);
    }
}