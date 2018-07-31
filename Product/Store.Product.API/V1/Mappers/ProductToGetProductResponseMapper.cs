using System;
using Store.Common.Infra;
using Store.Product.API.V1.Models.Response;
using Store.Product.Domain.Entities;

namespace Store.Product.API.V1.Mappers
{
    public class ProductToGetProductResponseMapper : IMapper<Domain.Entities.Product, GetProductResponse>
    {
        public GetProductResponse Map(Domain.Entities.Product source)
        {
            return new GetProductResponse
            {
                Key = source.Key,
                Code = source.Code,
                Name = source.Name,
                Properties = source.Properties,
                ModifiedOn = source.ModifiedOn,
                CreatedOn = source.CreatedOn
            };
        }
    }
}
