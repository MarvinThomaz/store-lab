using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreateLaunchRequestToLaunchMapper : ICreateLaunchRequestToLaunchMapper
    {
        public Launch Map(CreateLaunchRequest source)
        {
            return new Launch
            {
                Type = source.Type,
                Value = source.Value
            };
        }
    }
}