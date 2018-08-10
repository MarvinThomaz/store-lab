using Store.Common.List;
using Store.Product.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Store.Product.Domain.Repositories
{
    public interface IProductGroupRepository
    {
        Task CreateProductGroupAsync(ProductGroup group);
        Task UpdateProductGroupAsync(ProductGroup group, string groupKey);
        Task UpdateEnableProductGroupStatusAsync(string groupKey, bool isEnabled);
        Task<ProductGroup> GetProductGroupByKeyAsync(string groupKey);
        Task<IPagingList<ProductGroup>> GetAllProductGroupsAsync(int page, int recordsPerPage);
        Task AddProductInProductGroupAsync(string groupKey, Entities.Product product, DateTime modifiedOn);
        Task RemoveProductFromProductGroupAsync(string groupKey, string productKey, DateTime modifiedOn);
        Task UpdatePriceOfProductGroupAsync(string groupKey, Price price, DateTime modifiedOn);
        Task AddLaunchInProductGroupAsync(string groupKey, Launch launch, DateTime modifiedOn);
        Task UpdateLaunchAvailableStatusInProductAsync(string groupKey, string launchKey, bool isAvailable, DateTime modifiedOn);
    }
}