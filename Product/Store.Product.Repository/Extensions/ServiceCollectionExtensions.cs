using Microsoft.Extensions.DependencyInjection;
using Store.Product.Domain.Repositories;
using Store.Product.Repositories;

namespace Store.Product.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}