using Store.Common.Interfaces;
using Store.Product.Presentation.V1.Models.Response;
using System.Collections.Generic;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface IProductToListProductResponseMapper : IMapper<IPagingList<Domain.Entities.Product>, IPagingList<ListProductResponse>> { }
}