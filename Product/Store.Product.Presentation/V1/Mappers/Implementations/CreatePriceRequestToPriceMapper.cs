using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreatePriceRequestToPriceMapper : ICreatePriceRequestToPriceMapper
    {
        private readonly ICreateCoinRequestToCoinMapper _coinMapper;

        public CreatePriceRequestToPriceMapper(ICreateCoinRequestToCoinMapper coinMapper)
        {
            _coinMapper = coinMapper;
        }

        public Price Map(CreatePriceRequest source)
        {
            var coin = _coinMapper.Map(source.Coin);

            return new Price
            {
                Coin = coin,
                Value = source.Value
            };
        }
    }
}