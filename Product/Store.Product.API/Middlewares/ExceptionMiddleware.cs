using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

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