using Store.Common.Attributes;
using Store.Common.Builders;
using Store.Common.Entities;
using Store.Common.Exceptions;
using Store.Common.Extensions;
using Store.Common.Interfaces;
using Store.Product.Domain.Delegates;
using Store.Product.Domain.Entities;
using Store.Product.Domain.EventArgs;
using Store.Product.Domain.Repositories;
using Store.Product.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Product.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private const string ProductKeyName = nameof(Domain.Entities.Product.Key);
        private const string FileTypeName = "Type";
        private const string ProfileTypeName = "profile";
        private const string PhotoTypeName = "photo";
        private const string ProductName = nameof(Domain.Entities.Product);

        private readonly IProductRepository _repository;
        private readonly IFileUploader _uploader;

        public ProductApplicationService(IProductRepository repository, IFileUploader uploader)
        {
            _repository = repository;
            _uploader = uploader;
        }

        public event AddLaunchToProductEventHandler LaunchAddedToProduct;
        public event AddOrUpdateProductPropertyEventHandler PropertyAddedOrUpdatedInProduct;
        public event DisableProductEventHandler ProductDisabled;
        public event RegisterNewProductEventHandler ProductRegisted;
        public event RemovePropertyFromProductEventHandler ProductPropertyRemoved;
        public event UnavailableProductLaunchEventHandler ProductLaunchUnavailable;
        public event UpdateProductNameEventHandler ProductNameUpdated;
        public event UpdateProductPriceEventHandler ProductPriceUpdated;

        public async Task AddLaunchToProductAsync([Validate(true, 36, 36)]string productKey, Launch launch)
        {
            var keyValidation = productKey.Validate();
            var launchValidation = launch.Validate();

            if (keyValidation.IsValid() && launchValidation.IsValid())
            {
                var product = await _repository.GetProductByKeyAsync(productKey);

                if (product != null)
                {
                    launch.Key = KeyBuilder.Build();

                    product.ModifiedOn = DateTime.Now;

                    product.Launches.Add(launch);

                    await _repository.UpdateProductAsync(product, productKey);

                    var args = new AddLaunchToProductEventArgs { Launch = launch, ProductKey = productKey };

                    LaunchAddedToProduct?.Invoke(this, args);
                }
            }
            else
                throw new EntityException(keyValidation.Aggregate(launchValidation));
        }

        public async Task AddOrUpdateProductPropertyAsync(ProductProperty property, [Validate(true, 36, 36)]string productKey)
        {
            var keyValidation = productKey.Validate();
            var propertyValidation = property.Validate();

            if (keyValidation.IsValid() && propertyValidation.IsValid())
            {
                var product = await _repository.GetProductByKeyAsync(productKey);

                if (product != null)
                {
                    if (product.Properties.Select(p => p.Name).Contains(property.Name))
                    {
                        product.Properties.ForEach(p =>
                        {
                            if (p.Name == property.Name)
                                p.Value = property.Value;
                        });
                    }
                    else
                    {
                        product.Properties.Add(property);
                    }

                    product.ModifiedOn = DateTime.Now;

                    await _repository.UpdateProductAsync(product, productKey);

                    var args = new AddOrUpdateProductPropertyEventArgs { ProductKey = productKey, Property = property };

                    PropertyAddedOrUpdatedInProduct?.Invoke(this, args);
                }
            }
            else
                throw new EntityException(keyValidation.Aggregate(propertyValidation));
        }

        public async Task DisableProductAsync([Validate(true, 36, 36)]string productKey)
        {
            var keyValidation = productKey.Validate();

            if (keyValidation.IsValid())
            {
                await _repository.UpdateEnableProductStatusAsync(productKey, false, DateTime.Now);

                var args = new DisableProductEventArgs { ProductKey = productKey };

                ProductDisabled?.Invoke(this, args);
            }
            else
                throw new EntityException(keyValidation);
        }

        public async Task<Domain.Entities.Product> GetProductByKeyAsync([Validate(true, 36, 36)]string productKey)
        {
            return await _repository.GetProductByKeyAsync(productKey);
        }

        public async Task<IPagingList<Domain.Entities.Product>> GetProductsAsync(int page, int recordsPerPage)
        {
            return await _repository.GetAllProductsAsync(page, recordsPerPage);
        }

        public async Task RegisterNewProductAsync(Domain.Entities.Product product, List<RequestFile> photos, RequestFile profile)
        {
            const string profilePhotoName = nameof(product.ProfilePhoto);
            const string photosName = nameof(product.Photos);
            const string bucketName = nameof(profile.Bucket);

            var productValidation = product.Validate(profilePhotoName, photosName);
            var profileValidation = profile.Validate(bucketName);
            var photosValidation = photos?.SelectMany(p => p.Validate(bucketName));

            if (productValidation.IsValid() && profileValidation.IsValid() && photosValidation.IsValid())
            {
                await _repository.CreateProductAsync(product);

                _uploader.FileUploaded += OnPhotoUploaded;

                profile.Bucket = $"{ProductName}-{product.Key}-{ProfileTypeName}-{profile.Key}".ToLower();
                profile.Metadata = new Dictionary<string, string>
                {
                    { ProductKeyName, product.Key },
                    { FileTypeName, ProfileTypeName }
                };

                photos?.ForEach(p =>
                {
                    p.Bucket = $"{ProductName}-{product.Key}-{PhotoTypeName}-{p.Key}".ToLower();
                    p.Metadata = new Dictionary<string, string>
                    {
                        { ProductKeyName, product.Key },
                        { FileTypeName, PhotoTypeName }
                    };
                });

                await _uploader.UploadAsync(profile);
                await _uploader.UploadAllAsync(photos);

                var args = new RegisterNewProductEventArgs { Product = product };

                ProductRegisted?.Invoke(this, args);
            }
            else
                throw new EntityException(productValidation.Aggregate(profileValidation).Aggregate(photosValidation));
        }

        private async Task OnPhotoUploaded(object sender, Common.EventArgs.UploadFileEventArgs args)
        {
            var productKey = args.Request.Metadata[ProductKeyName];
            var imageType = args.Request.Metadata[FileTypeName];
            var product = await _repository.GetProductByKeyAsync(productKey);

            if (imageType == ProfileTypeName)
            {
                product.ProfilePhoto = args.Response;
            }
            else if(imageType == PhotoTypeName)
            {
                if (product.Photos == null)
                    product.Photos = new List<ResponseFile>();

                product.Photos.Add(args.Response);
            }

            await _repository.UpdateProductAsync(product, productKey);
        }

        public async Task RemovePropertyFromProductAsync([Validate(true, 50, 2)]string propertyName, [Validate(true, 36, 36)]string productKey)
        {
            var keyValidation = productKey.Validate();
            var propertyKeyValidation = propertyName.Validate();

            if (keyValidation.IsValid() && propertyKeyValidation.IsValid())
            {
                var product = await _repository.GetProductByKeyAsync(productKey);

                if (product != null)
                {
                    var property = product.Properties?.FirstOrDefault(p => p.Name == propertyName);

                    if (property != null)
                    {
                        product.Properties.Remove(property);

                        product.ModifiedOn = DateTime.Now;

                        await _repository.UpdateProductAsync(product, productKey);

                        var args = new RemovePropertyFromProductEventArgs { ProductKey = productKey, PropertyName = propertyName };

                        ProductPropertyRemoved?.Invoke(this, args);
                    }
                }
            }
            else
                throw new EntityException(keyValidation.Aggregate(propertyKeyValidation));
        }

        public async Task UnavailableProductLaunchAsync([Validate(true, 36, 36)]string productKey, [Validate(true, 36, 36)]string launchKey)
        {
            var keyValidation = productKey.Validate();
            var launchKeyValidation = launchKey.Validate();

            if (keyValidation.IsValid() && launchKeyValidation.IsValid())
            {
                await _repository.UpdateLaunchAvailableStatusInProductAsync(productKey, launchKey, false, DateTime.Now);

                var args = new UnavailableProductLaunchEventArgs { LaunchKey = launchKey, ProductKey = productKey };

                ProductLaunchUnavailable?.Invoke(this, args);
            }
            else
                throw new EntityException(keyValidation.Aggregate(launchKeyValidation));
        }

        public async Task UpdateProductNameAsync([Validate(true, 50, 2)]string name, [Validate(true, 36, 36)]string productKey)
        {
            var nameValidation = name.Validate();
            var productKeyValidation = productKey.Validate();

            if (nameValidation.IsValid() && productKeyValidation.IsValid())
            {
                await _repository.UpdateProductNameAsync(productKey, name, DateTime.Now);

                var args = new UpdateProductNameEventArgs { Name = name, ProductKey = productKey };

                ProductNameUpdated?.Invoke(this, args);
            }
            else
                throw new EntityException(nameValidation.Aggregate(productKeyValidation));
        }

        public async Task UpdateProductPriceAsync([Validate(true, 36, 36)]string productKey, Price price)
        {
            var keyValidation = productKey.Validate();
            var priceValidation = price.Validate();

            if (keyValidation.IsValid() && priceValidation.IsValid())
            {
                await _repository.UpdatePriceOfProductAsync(productKey, price, DateTime.Now);

                var args = new UpdateProductPriceEventArgs { Price = price, ProductKey = productKey };

                ProductPriceUpdated?.Invoke(this, args);
            }
            else
                throw new EntityException(keyValidation.Aggregate(priceValidation));
        }
    }
}