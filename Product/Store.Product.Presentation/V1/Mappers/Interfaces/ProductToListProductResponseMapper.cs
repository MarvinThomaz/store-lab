using System.Collections.Generic;
using System.Linq;
using Store.Common.Infra;
using Store.Product.API.V1.Models.Response;

namespace Store.Product.API.V1.Mappers
{
    public class ProductToListProductResponseMapper : IMapper<IEnumerable<Domain.Entities.Product>, IEnumerable<ListProductResponse>>
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