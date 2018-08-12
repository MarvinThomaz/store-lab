using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreatePropertyRequestToPropertyMapper : ICreatePropertyRequestToPropertyMapper
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