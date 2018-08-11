using Store.Common.Infra;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;

namespace Store.Product.API.V1.Mappers
{
    public class CreatePropertyRequestToPropertyMapper : IMapper<CreatePropertyRequest, ProductProperty>
    {
        public ProductProperty Map(CreatePropertyRequest source)
        {
            return new ProductProperty
            {
                Name = source.Name,
                Value = source.Value
            };
        }
    }
}