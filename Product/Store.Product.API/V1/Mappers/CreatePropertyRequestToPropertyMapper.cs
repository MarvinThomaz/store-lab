using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;

namespace Store.Product.API.V1.Mappers
{
    public class CreatePropertyRequestToPropertyMapper : IMapper<CreatePropertyRequest, Property>
    {
        public Property Map(CreatePropertyRequest source)
        {
            return new Property
            {
                Name = source.Name,
                Value = source.Value
            };
        }
    }
}