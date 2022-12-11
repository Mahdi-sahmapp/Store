using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Web.MiddleWares
{
    public class MiddlewareExceptionHandler
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILoggerFactory _logger;
        private readonly RequestDelegate _next;

        public MiddlewareExceptionHandler(IWebHostEnvironment env, ILoggerFactory logger, RequestDelegate next)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                
                //Create default
                var result = HandleServerError(context, exception, options);

                //change
                result = HandleResualt(context, exception, result, options);
                
                await context.Response.WriteAsync(result);
            }
        }

        private static string HandleServerError(HttpContext context, Exception exception, JsonSerializerOptions options)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500                
            return JsonSerializer.Serialize(new ApiToReturn(500, exception.Message), options);
        }


        private string HandleResualt(HttpContext context, Exception exception, string result, JsonSerializerOptions options)
        {
            switch (exception)
            {
                case NotFoundEntityException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ApiToReturn(404, notFoundException.Message
                        , notFoundException.Messages, exception.Message), options);
                    break;

                case BadRequestEntityException badRequestException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new ApiToReturn(400, badRequestException.Message, badRequestException.Messages
                        , badRequestException.Message), options);
                    break;

                case ValidationEntityException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new ApiToReturn(400, validationException.Message
                        , validationException.Messages, exception.Message), options);
                    break;
            }

            return result;
        }
    }
}
