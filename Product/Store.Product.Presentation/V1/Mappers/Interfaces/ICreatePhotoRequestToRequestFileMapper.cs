using Store.Common.Entities;
using Store.Common.Interfaces;
using Store.Product.Presentation.V1.Models.Request;

namespace Store.Product.Presentation.V1.Mappers.Interfaces
{
    public interface ICreatePhotoRequestToRequestFileMapper : IMapper<CreatePhotoRequest, RequestFile>  { }
}
