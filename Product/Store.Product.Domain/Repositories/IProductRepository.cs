<<<<<<< HEAD
﻿using System;
using System.Threading.Tasks;
using Store.Common.List;
=======
﻿using Store.Common.Interfaces;
using Store.Product.Domain.Entities;
using System;
using System.Threading.Tasks;
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103

namespace Store.Product.Domain.Repositories
{
    public interface IProductRepository
    {
<<<<<<< HEAD
        Task CreateProductAsync(Entities.Product product);
        Task UpdateProductAsync(Domain.Entities.Product product, string productKey);
        Task UpdateDeletedStatusOfProductAsync(string productKey, bool isDeleted, DateTime modifiedOn);
        Task UpdateNameOfProductAsync(string productKey, string name, DateTime modifiedOn);
        Task<Entities.Product> GetProductByKeyAsync(string key);
        Task<IPagingList<Entities.Product>> GetProductsByDeleteStatusAsync(bool isDeleted, int page, int recordsPerPage);
=======
        Task CreateProductAsync(Entities.Product product);
        Task UpdateProductAsync(Entities.Product product, string productKey);
        Task UpdateEnableProductStatusAsync(string productKey, bool isEnabled, DateTime modifiedOn);
        Task<Entities.Product> GetProductByKeyAsync(string productKey);
        Task<IPagingList<Entities.Product>> GetAllProductsAsync(int page, int recordsPerPage);
        Task AddPropertyInProductAsync(string productKey, ProductProperty property, DateTime modifiedOn);
        Task UpdatePropertyInProductAsync(string productKey, ProductProperty property, DateTime modifiedOn);
        Task RemovePropertyFromProductAsync(string productKey, string propertyName, DateTime modifiedOn);
        Task UpdatePriceOfProductAsync(string productKey, Price price, DateTime modifiedOn);
        Task AddLaunchInProductAsync(string productKey, Launch launch, DateTime modifiedOn);
        Task UpdateLaunchAvailableStatusInProductAsync(string productKey, string launchKey, bool isAvailable, DateTime modifiedOn);
        Task UpdateProductNameAsync(string productKey, string name, DateTime modifiedOn);
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103
    }
}