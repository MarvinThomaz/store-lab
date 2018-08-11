using Store.Common.Attributes;
using Store.Common.Config;
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

        public async Task AddLaunchToProductAsync([Validate(true, 36, 36)] string productKey, Launch launch)
        {
            var productValidations = productKey.Validate();
            var launchValidations = launch.Validate();

            if (launchValidations.IsValid && productValidations.IsValid)
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
                throw new EntityExcpetion(launchValidations.Aggregate(productValidations).ToArray());
        }

        public async Task AddOrUpdateProductPropertyAsync(ProductProperty property, [Validate(true, 36, 36)] string productKey)
        {
            var productValidations = productKey.Validate();
            var propertyValidations = property.Validate();

            if (propertyValidations.IsValid && productValidations.IsValid)
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
                throw new EntityExcpetion(propertyValidations.Aggregate(productValidations).ToArray());
        }

        public async Task DisableProductAsync([Validate(true, 36, 36)] string productKey)
        {
            var productValidations = productKey.Validate();

            if (productValidations.IsValid)
            {
                await _repository.UpdateEnableProductStatusAsync(productKey, false, DateTime.Now);

                var args = new DisableProductEventArgs
                {
                    ProductKey = productKey
                };

                ProductDisabled?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(productValidations);
        }

        public async Task<Domain.Entities.Product> GetProductByKeyAsync([Validate(true, 36, 36)] string productKey)
        {
            var productValidations = productKey.Validate();

            if (!productValidations.IsValid)
                return null;

            return await _repository.GetProductByKeyAsync(productKey);
        }

        public async Task<IPagingList<Domain.Entities.Product>> GetProductsAsync(int page, int recordsPerPage)
        {
            return await _repository.GetAllProductsAsync(page, recordsPerPage);
        }

        public async Task RegisterNewProductAsync(Domain.Entities.Product product)
        {
            product.Key = KeyGenerator.New();

            var productValidations = product.Validate();

            if (!productValidations.IsValid)
            {
                throw new EntityExcpetion(productValidations);
            }

            await _repository.CreateProductAsync(product);

            var args = new RegisterNewProductEventArgs
            {
                Product = product
            };

            ProductRegisted?.Invoke(this, args);
        }

        public async Task RemovePropertyFromProductAsync([Validate(true, 50, 2)] string propertyName, [Validate(true, 36, 36)] string productKey)
        {
            var productValidations = productKey.Validate();
            var propertyValidations = propertyName.Validate();

            if (productValidations.IsValid && propertyValidations.IsValid)
            {
                await _repository.RemovePropertyFromProductAsync(productKey, propertyName, DateTime.Now);

                var args = new RemovePropertyFromProductEventArgs
                {
                    ProductKey = productKey,
                    PropertyName = propertyName
                };

                ProductPropertyRemoved?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(productValidations.Aggregate(propertyValidations).ToArray());
        }

        public async Task UnavailableProductLaunchAsync([Validate(true, 36, 36)] string productKey, [Validate(true, 36, 36)] string launchKey)
        {
            var productValidations = productKey.Validate();
            var launchValidations = launchKey.Validate();

            if (productValidations.IsValid && launchValidations.IsValid)
            {
                await _repository.UpdateLaunchAvailableStatusInProductAsync(productKey, launchKey, false, DateTime.Now);

                var args = new UnavailableProductLaunchEventArgs
                {
                    LaunchKey = launchKey,
                    ProductKey = productKey
                };

                ProductLaunchUnavailable?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(launchValidations.Aggregate(productValidations).ToArray());
        }

        public async Task UpdateProductNameAsync([Validate(true, 50, 2)] string name, [Validate(true, 36, 36)] string productKey)
        {
            var productValidations = productKey.Validate();
            var nameValidations = name.Validate();

            if (productValidations.IsValid && nameValidations.IsValid)
            {
                await _repository.UpdateProductNameAsync(productKey, name, DateTime.Now);

                var args = new UpdateProductNameEventArgs
                {
                    Name = name,
                    ProductKey = productKey
                };

                ProductNameUpdated?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(productValidations.Aggregate(nameValidations).ToArray());
        }

        public async Task UpdateProductPriceAsync([Validate(true, 36, 36)] string productKey, Price price)
        {
            var productValidations = productKey.Validate();
            var priceValidations = price.Validate();

            if (priceValidations.IsValid && productValidations.IsValid)
            {
                await _repository.UpdatePriceOfProductAsync(productKey, price, DateTime.Now);

                var args = new UpdateProductPriceEventArgs
                {
                    Price = price,
                    ProductKey = productKey
                };

                ProductPriceUpdated?.Invoke(this, args);
            }
            else
                throw new EntityExcpetion(productValidations.Aggregate(priceValidations).ToArray());
        }
    }
}
