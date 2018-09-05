using Store.Common.Builders;
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
            if (source == null)
                return null;

            return new RequestFile
            {
                Key = KeyBuilder.Build(),
                ContentType = "image",
                Data = source.Data,
                Name = source.Name
            };
        }
    }
}
