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
            Stream originalBodyStream = context.Response.Body;

            var modifiedBodyStream = new MemoryStream();
            context.Response.Body = modifiedBodyStream;

            var breadResponse = new BreadResponse();

            try
            {
                await next.Invoke(context);

                string body = await GetResponseBodyStringAsync(context.Response);
                
                breadResponse.IsSuccess = true;
                breadResponse.Data = body;                               
            }
            catch (Exception ex)
            {                
                breadResponse.IsSuccess = false;
                breadResponse.Message = ex.Message;
            }
            finally
            {
                string jsonResponse = BreadJsonHttpResponseMessageHelper.Create(context, breadResponse);

                await context.Response.WriteAsync(jsonResponse);

                await CopyResponseBodyToOriginalStreamAsync(originalBodyStream, modifiedBodyStream);
            }
        }

        private static bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments(SwaggerUrlPath);
        }

        private static async Task<string> GetResponseBodyStringAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string responseBodyString = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return responseBodyString;
        }        

        private static async Task CopyResponseBodyToOriginalStreamAsync(Stream originalBodyStream, MemoryStream responseBody)
        {
            // with .NET Core one cannot modify the original stream, so it has to be copied from the modified stream
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
