using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Response;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class ProductToGetProductResponseMapper : IProductToGetProductResponseMapper
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
