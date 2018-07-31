using Microsoft.Extensions.DependencyInjection;
using Store.Common.Infra;
using Store.Product.API.V1.Mappers;
using Store.Product.API.V1.Models.Request;
using Store.Product.Domain.Entities;
using ProductEntity = Store.Product.Domain.Entities.Product;

namespace Store.Product.API.Config
{
    public static class MapperIoc
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<CreateProductRequest, ProductEntity>, CreateProductRequestToProductMapper>();
            services.AddSingleton<IMapper<CreatePropertyRequest, Property>, CreatePropertyRequestToPropertyMapper>();
        }
    }
}