using System;
using System.Threading.Tasks;
using Store.Common.List;

namespace Store.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Entities.Product product);
        Task UpdateProductAsync(Domain.Entities.Product product, string productKey);
        Task UpdateDeletedStatusOfProductAsync(string productKey, bool isDeleted, DateTime modifiedOn);
        Task UpdateNameOfProductAsync(string productKey, string name, DateTime modifiedOn);
        Task<Entities.Product> GetProductByKeyAsync(string key);
        Task<IPagingList<Entities.Product>> GetProductsByDeleteStatusAsync(bool isDeleted, int page, int recordsPerPage);
    }
}
