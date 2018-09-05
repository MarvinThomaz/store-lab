using Store.Common.Builders;
using Store.Common.Interfaces;
using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;
using System.Linq;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreateProductRequestToProductMapper : ICreateProductRequestToProductMapper
    {
        private readonly ICreatePropertyRequestToPropertyMapper _propertyMapper;
        private readonly ICreateLaunchRequestToLaunchMapper _launchMapper;
        private readonly ICreatePriceRequestToPriceMapper _priceMapper;

        public CreateProductRequestToProductMapper(ICreatePropertyRequestToPropertyMapper propertyMapper,
            ICreateLaunchRequestToLaunchMapper launchMapper,
            ICreatePriceRequestToPriceMapper priceMapper)
        {
            _propertyMapper = propertyMapper;
            _launchMapper = launchMapper;
            _priceMapper = priceMapper;
        }

        public ProductEntity Map(CreateProductRequest source)
        {
            var properties = source?.Properties?.Select(p => _propertyMapper.Map(p)).ToList();
            var launches = source?.Launches?.Select(l => _launchMapper.Map(l)).ToList();
            var price = _priceMapper.Map(source.Price);

            return new ProductEntity
            {
                Key = KeyBuilder.Build(),
                Code = source.Code,
                Name = source.Name,
                Properties = properties,
                Launches = launches,
                Price = price,
                IsEnabled = true
            };
        }
    }
}