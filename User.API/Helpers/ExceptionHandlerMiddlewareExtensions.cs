using Microsoft.AspNetCore.Builder;
using WebApi.Helpers;

namespace User.API.Helpers
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
