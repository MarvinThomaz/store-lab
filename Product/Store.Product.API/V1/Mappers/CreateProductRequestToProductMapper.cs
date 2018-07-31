using System.Linq;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.API.V1.Mappers
{
    public class CreateProductRequestToProductMapper : IMapper<CreateProductRequest, ProductEntity>
    {
        private readonly IMapper<CreatePropertyRequest, Property> _propertyMapper;

        public CreateProductRequestToProductMapper(IMapper<CreatePropertyRequest, Property> propertyMapper)
        {
            _propertyMapper = propertyMapper;
        }

        public ProductEntity Map(CreateProductRequest source)
        {
            var properties = source?.Properties?.Select(p => _propertyMapper.Map(p)).ToList();

            return new ProductEntity
            {
                Code = source.Code,
                Name = source.Name,
                Properties = properties
            };
        }
    }
}