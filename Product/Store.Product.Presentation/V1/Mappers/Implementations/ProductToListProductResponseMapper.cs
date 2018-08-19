using Store.Product.Presentation.V1.Mappers.Interfaces;
using Store.Product.Presentation.V1.Models.Response;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD:Product/Store.Product.API/V1/Mappers/ProductToListProductResponseMapper.cs
using Microsoft.AspNetCore.Mvc;
using Store.Common.Infra;
using Store.Common.List;
using Store.Product.API.V1.Controllers;
using Store.Product.API.V1.Models.Response;
=======
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103:Product/Store.Product.Presentation/V1/Mappers/Implementations/ProductToListProductResponseMapper.cs

namespace Store.Product.Presentation.V1.Mappers.Implementations
{
<<<<<<< HEAD:Product/Store.Product.API/V1/Mappers/ProductToListProductResponseMapper.cs
    public class ProductToListProductResponseMapper : IMapper<IPagingList<Domain.Entities.Product>, IPagingList<ListProductResponse>>
    {
        private readonly IUrlHelper _urlHelper;

        public ProductToListProductResponseMapper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public IPagingList<ListProductResponse> Map(IPagingList<Domain.Entities.Product> source)
        {
            var list = source.Records.Select(Map);

            return new PagingList<ListProductResponse>(source.Page, source.RecordsPerPage, source.TotalRecords, list);
        }

        private ListProductResponse Map(Domain.Entities.Product source)
        {

            var urlParameters = new { controller = "properties", key = source.Key };
            var link = _urlHelper.Link(PropertiesController.GetPropertiesByProductRouteName, urlParameters);

            return new ListProductResponse
            {
                Name = source.Name,
                Code = source.Code,
                Key = source.Key,
                CreatedOn = source.CreatedOn,
                ModifiedOn = source.ModifiedOn,
                Properties = link
            };
=======
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
>>>>>>> f04bd6248628029a6dbb2b819a33894afafd1103:Product/Store.Product.Presentation/V1/Mappers/Implementations/ProductToListProductResponseMapper.cs
        }
    }
}