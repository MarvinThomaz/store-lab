using Store.Common.Entities;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Request;
using System;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class CreatePhotoRequestToRequestFileMapper : ICreatePhotoRequestToRequestFileMapper
    {
        public RequestFile Map(CreatePhotoRequest source)
        {
            return new RequestFile
            {
                ContentType = "",
                Data = source.Data,
                Name = source.Name
            };
        }
    }
}
