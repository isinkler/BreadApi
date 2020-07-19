using Microsoft.AspNetCore.Http;

using System;
using System.IO;
using System.Threading.Tasks;

namespace Bread.WebApi.Middlewares
{
    public class BreadResponseMiddleware
    {
        private const string SwaggerUrlPath = "/swagger";

        private readonly RequestDelegate next;

        public BreadResponseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (IsSwagger(context))
            {
                await next(context);
                return;
            }

            await ChangeResponseBodyAsync(context);
        }

        private async Task ChangeResponseBodyAsync(HttpContext context)
        {            
            try
            {
                await next.Invoke(context);               
            }
            catch (Exception ex)
            {
                // saving the original reference to the stream, before the response is formed, because we
                // can't modify this
                Stream originalBodyStream = context.Response.Body;

                // assigning a new MemoryStream object to the response body, this can be modified
                var modifiedBodyStream = new MemoryStream();
                context.Response.Body = modifiedBodyStream;

                string jsonResponse = GetExceptionJsonResponse(context, ex);

                await context.Response.WriteAsync(jsonResponse);

                await CopyModifiedBodyStreamToOriginalBodyStreamAsync(modifiedBodyStream, originalBodyStream);
            }
        }

        private static string GetExceptionJsonResponse(HttpContext context, Exception ex)
        {
            var breadResponse = new BreadResponse()
            {
                IsSuccess = false,
                Message = ex.Message
            };

            string jsonResponse = BreadJsonHttpResponseMessageHelper.Create(context, breadResponse);

            return jsonResponse;
        }

        private static bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments(SwaggerUrlPath);
        }              

        private static async Task CopyModifiedBodyStreamToOriginalBodyStreamAsync(MemoryStream modifiedBodyStream, Stream originalBodyStream)
        {
            // with .NET Core we can't modify the original stream, so it has to be copied from the modified stream
            modifiedBodyStream.Seek(0, SeekOrigin.Begin);
            await modifiedBodyStream.CopyToAsync(originalBodyStream);
        }
    }
}
