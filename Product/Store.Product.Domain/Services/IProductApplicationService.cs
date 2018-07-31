using System;
using System.Threading.Tasks;
using Store.Common.List;
using Store.Product.Domain.Entities;

namespace Store.Product.Domain.Services
{
    public interface IProductApplicationService
    {
        Task RegisterNewProductAsync(Entities.Product product);
        Task AddOrUpdatePropertyAsync(Property property, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string key);
        Task<IPagingList<Entities.Product>> GetProductsAsync(int page, int recordsPerPage);
        Task UpdateProduct(string productKey, string productName);
        Task RemoveProperty(string propertyKey, string productKey);
        Task DisableProduct(string productKey);
    }
}
