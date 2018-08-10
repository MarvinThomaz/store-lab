using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddOrUpdatePropertyAsync(ProductProperty property, string productKey)
        {
            var errors = property.ValidateEntity();

            if(!errors.IsValid)
            {
                throw new EntityExcpetion(errors);
            }

            var product = await _repository.GetProductByKeyAsync(productKey);

            if (product.Properties == null)
            {
                product.Properties = new List<ProductProperty>();
            }

            if (product.Properties?.Any(p => p.Name == property.Name) == true)
            {
                var persistedProperty = product.Properties.FirstOrDefault(p => p.Name == property.Name);

                persistedProperty.Value = property.Value;
            }
            else
            {
                product.Properties.Add(property);
            }

            product.ModifiedOn = DateTime.UtcNow;

            await _repository.UpdateProductAsync(product, product.Key);
        }

        public async Task DisableProduct(string productKey)
        {
            if (productKey != null)
            {
                var product = await _repository.GetProductByKeyAsync(productKey);

                product.IsEnabled = true;
                product.ModifiedOn = DateTime.UtcNow;

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
            if (propertyKey != null && productKey != null)
            {
                var product = await _repository.GetProductByKeyAsync(productKey);

                if (product != null)
                {
                    var property = product.Properties.FirstOrDefault(p => p.Name == propertyKey);

                    if (property != null)
                    {
                        product.Properties.Remove(property);
                        product.ModifiedOn = DateTime.UtcNow;

                        await _repository.UpdateProductAsync(product, productKey);
                    }
                }
            }
        }

        public async Task UpdateProduct(Domain.Entities.Product product, string productKey)
        {
            var errors = product.ValidateEntity();

            if (!errors.IsValid)
            {
                throw new EntityExcpetion(errors);
            }

            var persistedProduct = await _repository.GetProductByKeyAsync(productKey);

            if (persistedProduct.Name != product.Name)
            {
                persistedProduct.Name = product.Name;

                await _repository.UpdateProductAsync(product, productKey);
            }
        }
    }
}
