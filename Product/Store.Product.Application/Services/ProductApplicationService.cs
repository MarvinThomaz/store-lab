using Store.Common.Config;
using Store.Common.Contracts;
using Store.Common.Enums;
using Store.Common.Exceptions;
using Store.Common.Extensions;
using Store.Common.List;
using Store.Product.Domain.Delegates;
using Store.Product.Domain.Entities;
using Store.Product.Domain.EventArgs;
using Store.Product.Domain.Repositories;
using Store.Product.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Product.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _repository;

        public ProductApplicationService(IProductRepository repository)
        {
            _repository = repository;
        }

        public event AddLaunchToProductEventHandler LaunchAddedToProduct;
        public event AddOrUpdateProductPropertyEventHandler PropertyAddedOrUpdatedInProduct;
        public event DisableProductEventHandler ProductDisabled;
        public event RegisterNewProductEventHandler ProductRegisted;
        public event RemovePropertyFromProductEventHandler ProductPropertyRemoved;
        public event UnavailableProductLaunchEventHandler ProductLaunchUnavailable;
        public event UpdateProductNameEventHandler ProductNameUpdated;
        public event UpdateProductPriceEventHandler ProductPriceUpdated;

        public async Task AddLaunchToProductAsync(string productKey, Launch launch)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            var errors = launch.ValidateEntity();

            if (errors.IsValid)
            {
                await _repository.AddLaunchInProductAsync(productKey, launch, DateTime.Now);

                var args = new AddLaunchToProductEventArgs
                {
                    ProductKey = productKey,
                    Launch = launch
                };

                LaunchAddedToProduct?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(errors);
        }

        public async Task AddOrUpdateProductPropertyAsync(ProductProperty property, string productKey)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            var errors = property.ValidateEntity();

            if (errors.IsValid)
            {
                var product = await _repository.GetProductByKeyAsync(productKey);
                var savedProperty = product.Properties?.FirstOrDefault(p => p.Name == property.Name);

                if (savedProperty == null)
                {
                    await _repository.AddPropertyInProductAsync(productKey, property, DateTime.Now);
                }
                else
                {
                    await _repository.UpdatePropertyInProductAsync(productKey, property, DateTime.Now);
                }

                var args = new AddOrUpdateProductPropertyEventArgs
                {
                    ProductKey = productKey,
                    Property = property
                };

                PropertyAddedOrUpdatedInProduct?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(errors);
        }

        public async Task DisableProductAsync(string productKey)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            await _repository.UpdateEnableProductStatusAsync(productKey, false, DateTime.Now);

            var args = new DisableProductEventArgs
            {
                ProductKey = productKey
            };

            ProductDisabled?.Invoke(this, args);
        }

        public async Task<Domain.Entities.Product> GetProductByKeyAsync(string productKey)
        {
            if (productKey == null)
            {
                return null;
            }

            return await _repository.GetProductByKeyAsync(productKey);
        }

        public async Task<IPagingList<Domain.Entities.Product>> GetProductsAsync(int page, int recordsPerPage)
        {
            return await _repository.GetAllProductsAsync(page, recordsPerPage);
        }

        public async Task RegisterNewProductAsync(Domain.Entities.Product product)
        {
            product.Key = KeyGenerator.New();

            var errors = product.ValidateEntity();

            if (!errors.IsValid)
            {
                throw new EntityExcpetion(errors);
            }

            await _repository.CreateProductAsync(product);

            var args = new RegisterNewProductEventArgs
            {
                Product = product
            };

            ProductRegisted?.Invoke(this, args);
        }

        public async Task RemovePropertyFromProductAsync(string propertyName, string productKey)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            if (propertyName == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(propertyName));

                throw new EntityExcpetion(error);
            }

            await _repository.RemovePropertyFromProductAsync(productKey, propertyName, DateTime.Now);

            var args = new RemovePropertyFromProductEventArgs
            {
                ProductKey = productKey,
                PropertyName = propertyName
            };

            ProductPropertyRemoved?.Invoke(this, args);
        }

        public async Task UnavailableProductLaunchAsync(string productKey, string launchKey)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            if (launchKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(launchKey));

                throw new EntityExcpetion(error);
            }

            await _repository.UpdateLaunchAvailableStatusInProductAsync(productKey, launchKey, false, DateTime.Now);

            var args = new UnavailableProductLaunchEventArgs
            {
                LaunchKey = launchKey,
                ProductKey = productKey
            };

            ProductLaunchUnavailable?.Invoke(this, args);
        }

        public async Task UpdateProductNameAsync(string name, string productKey)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            if (name == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(name));

                throw new EntityExcpetion(error);
            }

            await _repository.UpdateProductNameAsync(productKey, name, DateTime.Now);

            var args = new UpdateProductNameEventArgs
            {
                Name = name,
                ProductKey = productKey
            };

            ProductNameUpdated?.Invoke(this, args);
        }

        public async Task UpdateProductPriceAsync(string productKey, Price price)
        {
            if (productKey == null)
            {
                var error = new Info(InfoType.NullableProperty, nameof(productKey));

                throw new EntityExcpetion(error);
            }

            var errors = price.ValidateEntity();

            if (errors.IsValid)
            {
                await _repository.UpdatePriceOfProductAsync(productKey, price, DateTime.Now);

                var args = new UpdateProductPriceEventArgs
                {
                    Price = price,
                    ProductKey = productKey
                };

                ProductPriceUpdated?.Invoke(this, args);
            }
        }
    }
}
