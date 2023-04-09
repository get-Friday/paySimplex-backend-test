using paySimplex.Domain.DTOs;
using paySimplex.Domain.Exceptions;
using System.Net;

namespace paySimplex.API.Configs
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await ExceptionTreatment(httpContext, ex);
            }
        }
        private static Task ExceptionTreatment(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case InvalidStartEndDateException:
                case EntityNotFoundException:
                    status = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case InvalidFileSizeException:
                    status = HttpStatusCode.RequestEntityTooLarge;
                    message = exception.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "An internal error ocurred. Please contact IT";
                    break;
            }

            ErrorDTO response = new(message);
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
