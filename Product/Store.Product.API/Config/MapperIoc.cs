using Microsoft.Extensions.DependencyInjection;
using Store.Product.Presentation.V1.Mappers.Implementations;
using Store.Product.Presentation.V1.Mappers.Interfaces;

namespace Store.Product.API.Config
{
    public static class MapperIoc
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<ICreateProductRequestToProductMapper, CreateProductRequestToProductMapper>();
            services.AddSingleton<ICreatePropertyRequestToPropertyMapper, CreatePropertyRequestToPropertyMapper>();
            services.AddSingleton<IUpdateProductRequestToProduct, UpdateProductRequestToProduct>();
            services.AddSingleton<IProductToListProductResponseMapper, ProductToListProductResponseMapper>();
            services.AddSingleton<IProductToGetProductResponseMapper, ProductToGetProductResponseMapper>();
        }
    }
}