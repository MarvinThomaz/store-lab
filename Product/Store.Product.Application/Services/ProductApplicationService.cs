using System.Threading.Tasks;
using Store.Common.Config;
using Store.Common.Exceptions;
using Store.Common.Extensions;
using Store.Common.List;
using Store.Product.Domain.Entities;
using Store.Product.Domain.Repositories;
using Store.Product.Domain.Services;

namespace Store.Product.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _repository;

        public ProductApplicationService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddOrUpdatePropertyAsync(Property property, string productKey)
        {
            var errors = property.ValidateEntity();

            if(!errors.IsValid)
            {
                throw new EntityExcpetion(errors);
            }

            await _repository.AddOrUpdatePropertyAsync(property, productKey);
        }

        public async Task DisableProduct(string productKey)
        {
            if (productKey != null)
            {
                var product = await _repository.GetProductByKeyAsync(productKey);

                product.IsDeleted = true;

                await _repository.UpdateProductAsync(product, productKey);
            }
        }

        public async Task<Domain.Entities.Product> GetProductByKeyAsync(string key)
        {
            if(key == null)
            {
                return null;
            }

            return await _repository.GetProductByKeyAsync(key);
        }

        public async Task<IPagingList<Domain.Entities.Product>> GetProductsAsync(int page, int recordsPerPage)
        {
            return await _repository.GetAllProductsAsync(page, recordsPerPage);
        }

        public async Task RegisterNewProductAsync(Domain.Entities.Product product)
        {
            product.Key = KeyGenerator.New();

            var errors = product.ValidateEntity();

            if(!errors.IsValid)
            {
                throw new EntityExcpetion(errors);
            }

            await _repository.CreateProductAsync(product);
        }

        public async Task RemoveProperty(string propertyKey, string productKey)
        {
            await _repository.RemovePropertyAsync(propertyKey, productKey);
        }

        public async Task UpdateProduct(Domain.Entities.Product product, string productKey)
        {
            await _repository.UpdateProductAsync(product, productKey);
        }
    }
}
