using Microsoft.Extensions.DependencyInjection;
using Store.Product.Presentation.V1.Mappers.Implementations;
using Store.Product.Presentation.V1.Mappers.Interfaces;

namespace Store.Product.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton<ICreateProductRequestToProductMapper, CreateProductRequestToProductMapper>();
            services.AddSingleton<ILaunchEnumToLaunchTypesMapper, LaunchEnumToLaunchTypesMapper>();
            services.AddSingleton<ICreatePropertyRequestToPropertyMapper, CreatePropertyRequestToPropertyMapper>();
            services.AddSingleton<IUpdateProductRequestToProduct, UpdateProductRequestToProduct>();
            services.AddSingleton<IProductToListProductResponseMapper, ProductToListProductResponseMapper>();
            services.AddSingleton<ICreateLaunchRequestToLaunchMapper, CreateLaunchRequestToLaunchMapper>();
            services.AddSingleton<ICreatePriceRequestToPriceMapper, CreatePriceRequestToPriceMapper>();
            services.AddSingleton<ICreateCoinRequestToCoinMapper, CreateCoinRequestToCoinMapper>();
        }
    }
}