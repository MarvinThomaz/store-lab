using Store.Common.List;
using Store.Product.Domain.Entities;
using System.Threading.Tasks;

namespace Store.Product.Domain.Services
{
    public interface IProductGroupApplicationService
    {
        Task RegisterNewProductGroupAsync(ProductGroup group);
        Task UpdateProductGroupAsync(ProductGroup group, string groupKey);
        Task DisableProductGroupAsync(string groupKey);
        Task<ProductGroup> GetProductGroupByKeyAsync(string groupKey);
        Task<IPagingList<ProductGroup>> GetAllProductGroupsAsync(int page, int recordsPerPage);
        Task AddProductInProductGroupAsync(string groupKey, Entities.Product product);
        Task RemoveProductFromProductGroupAsync(string groupKey, string productKey);
        Task UpdatePriceOfProductGroupAsync(string groupKey, Price price);
        Task AddLaunchInProductGroupAsync(string groupKey, Launch launch);
        Task UnavailableProductLauchAsync(string groupKey, string launchKey);
    }
}