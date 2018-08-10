using System;
using System.Threading.Tasks;
using Store.Common.List;
using Store.Product.Domain.Entities;

namespace Store.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Entities.Product product);
        Task UpdateProductAsync(Entities.Product product, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string key);
        Task<IPagingList<Entities.Product>> GetAllProductsAsync(int page, int recordsPerPage);
        Task AddOrUpdatePropertyInProduct(string productKey, string propertyName, string propertyValue, DateTime modifiedOn);
        Task RemovePropertyFromProduct(string productKey, string propertyName);
        Task UpdatePriceOfProduct(string productKey, Price price, DateTime modifiedOn);
        Task AddLaunchInProduct(string productKey, Launch launch, DateTime modifiedOn);
        Task UpdateLaunchAvailableStatusInProduct(string productKey, string launchKey, bool isAvailable, DateTime modifiedOn);
    }
}