using Store.Common.Interfaces;
using Store.Product.Domain.Entities;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface ICreatePropertyRequestToPropertyMapper : IMapper<CreatePropertyRequest, ProductProperty> { }
}