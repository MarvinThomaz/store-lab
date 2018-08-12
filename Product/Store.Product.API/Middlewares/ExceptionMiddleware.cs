using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Store.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace Store.Product.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityException exception)
            {
            }
            catch (Exception exception)
            {
            }
        }

        private async Task FormatException(HttpContext context, object data, int statusCode)
        {
            var json = JsonConvert.SerializeObject(data);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}