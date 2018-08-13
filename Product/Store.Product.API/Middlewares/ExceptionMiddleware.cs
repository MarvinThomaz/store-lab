using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Store.Common.Entities;
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
                await FormatException(context, exception.Errors, StatusCodes.Status422UnprocessableEntity);
            }
            catch (Exception)
            {
                var errors = new Errors();

                errors.AddError(Common.Enums.InfoType.InternalError, "");

                await FormatException(context, errors, StatusCodes.Status500InternalServerError);
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