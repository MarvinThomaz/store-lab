using System.Collections.Generic;
using System.Linq;
using Store.Common.Infra;
using Store.Common.List;
using Store.Product.API.V1.Models.Response;

namespace Store.Product.API.V1.Mappers
{
    public class ProductToListProductResponseMapper : IMapper<IPagingList<Domain.Entities.Product>, IPagingList<ListProductResponse>>
    {
        public IPagingList<ListProductResponse> Map(IPagingList<Domain.Entities.Product> source)
        {
            var list = source.Records.Select(Map);

            return new PagingList<ListProductResponse>(source.Page, source.RecordsPerPage, source.TotalRecords, list);
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