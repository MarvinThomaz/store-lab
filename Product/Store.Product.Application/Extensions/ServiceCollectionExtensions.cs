using Microsoft.Extensions.DependencyInjection;
using Store.Product.Application.Services;
using Store.Product.Domain.Services;

namespace Store.Product.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductApplicationService, ProductApplicationService>();
        }
    }
}