using Bread.WebApi.Middlewares;

using Microsoft.AspNetCore.Builder;

namespace Bread.WebApi.Extensions
{
    public static class ApiResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseBreadResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BreadResponseMiddleware>();
        }
    }
}
