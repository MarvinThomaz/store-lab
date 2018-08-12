using Store.Common.Infra;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface ICreateProductRequestToProductMapper : IMapper<CreateProductRequest, Domain.Entities.Product> { }
}