using Microsoft.Extensions.DependencyInjection;
using Store.Product.Repositories;
using Store.Product.Domain.Repositories;
using Store.Product.Domain.Services;
using Store.Product.Application.Services;

namespace Store.Product.API.Config
{
    public static class DomainIoc
    {
        public static void AddDomain(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();

            service.AddScoped<IProductApplicationService, ProductApplicationService>();
        }
    }
}