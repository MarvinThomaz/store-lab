using Store.Common.Interfaces;
using Store.Product.Presentation.V1.Models.Response;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface IProductToGetProductResponseMapper : IMapper<Domain.Entities.Product, GetProductResponse>
    {
    }
}