using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreateCoinRequestToCoinMapper : ICreateCoinRequestToCoinMapper
    {
        public Coin Map(CreateCoinRequest source)
        {
            return new Coin
            {
                Country = source.Country,
                Name = source.Name,
                Reference = source.Reference
            };
        }
    }
}