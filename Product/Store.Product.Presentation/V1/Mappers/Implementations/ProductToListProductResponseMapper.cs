using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class ProductToListProductResponseMapper : IProductToListProductResponseMapper
    {
        public IEnumerable<ListProductResponse> Map(IEnumerable<Domain.Entities.Product> source)
        {
            return source.Select(Map);
        }

        private ListProductResponse Map(Domain.Entities.Product source)
        {
            return new ListProductResponse
            {
                Name = source.Name,
                Code = source.Code,
                Key = source.Key,
                CreatedOn = source.CreatedOn,
                ModifiedOn = source.ModifiedOn
            };
        }
    }
}