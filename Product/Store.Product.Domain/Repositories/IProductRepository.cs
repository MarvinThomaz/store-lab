using System.Threading.Tasks;
using Store.Common.List;

namespace Store.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Entities.Product product);
        Task UpdateProductAsync(Entities.Product product, string productKey);
        Task<Entities.Product> GetProductByKeyAsync(string key);
        Task<IPagingList<Entities.Product>> GetAllProductsAsync(int page, int recordsPerPage);
    }
}
