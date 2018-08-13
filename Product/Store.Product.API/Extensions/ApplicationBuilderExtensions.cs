using Microsoft.AspNetCore.Builder;
using Store.Product.API.Middlewares;

namespace Store.Product.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseException(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}