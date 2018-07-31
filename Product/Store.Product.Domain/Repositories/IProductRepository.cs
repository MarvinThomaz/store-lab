using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.List;
using Store.Product.Domain.Entities;

namespace Store.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Entities.Product product);
        Task AddOrUpdatePropertyAsync(Property property, string productKey);
        Task RemovePropertyAsync(string propertyKey, string productKey);
        Task UpdateProductAsync(Entities.Product product, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string key);
        Task<IPagingList<Entities.Product>> GetAllProductsAsync(int page, int recordsPerPage);
    }
}
