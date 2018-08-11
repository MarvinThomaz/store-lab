using System;
using Store.Common.Infra;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;

namespace Store.Product.API.V1.Mappers
{
    public class UpdateProductRequestToProduct : IMapper<UpdateProductRequest, Domain.Entities.Product>
    {
        public Domain.Entities.Product Map(UpdateProductRequest source)
        {
            return new Domain.Entities.Product
            {
                Name = source.Name
            };
        }
    }
}
