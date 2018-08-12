using Store.Common.Infra;
using Store.Product.Presentation.V1.Models.Response;
using System.Collections.Generic;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface IProductToListProductResponseMapper : IMapper<IEnumerable<Domain.Entities.Product>, IEnumerable<ListProductResponse>> { }
}