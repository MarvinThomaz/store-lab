using Store.Common.Extensions;
using Store.Common.Interfaces;
using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Response;
using System.Linq;

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
    public class ProductToListProductResponseMapper : IProductToListProductResponseMapper
    {
        public IPagingList<ListProductResponse> Map(IPagingList<Domain.Entities.Product> source)
        {
            return source.Records.Select(Map).ToPagingList(source.Page, source.RecordsPerPage, source.TotalRecords);
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