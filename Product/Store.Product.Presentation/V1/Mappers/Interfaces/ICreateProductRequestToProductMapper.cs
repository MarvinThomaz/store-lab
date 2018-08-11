using Store.Common.Infra;
using Store.Product.API.V1.Models.Request;

namespace Store.Product.API.V1.Mappers
{
    public interface ICreateProductRequestToProductMapper : IMapper<CreateProductRequest, Domain.Entities.Product> { }
}