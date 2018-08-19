using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Product.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAPI(this IServiceCollection services)
        {
            services.AddScoped<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper>(svcProvider =>
            {
                var factory = svcProvider.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
                var accessor = svcProvider.GetService(typeof(IActionContextAccessor)) as IActionContextAccessor;

                return factory.GetUrlHelper(accessor.ActionContext);
            });
        }
    }
}
