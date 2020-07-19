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

                //string body = await GetResponseBodyStringAsync(context.Response);                               
                
                //breadResponse.IsSuccess = true;
                //breadResponse.Data = body;

                //if (body.Length == 0)
                //{
                //    modifiedBodyStream = new MemoryStream();
                //}
            }
            catch (Exception ex)
            {
                // saving the original reference to the stream, before the response is formed, because we
                // can't modify this
                Stream originalBodyStream = context.Response.Body;

                // assigning a new MemoryStream object to the response body, this can be modified
                var modifiedBodyStream = new MemoryStream();
                context.Response.Body = modifiedBodyStream;

                var breadResponse = BreadResponse.Create();

                breadResponse.IsSuccess = false;
                breadResponse.Message = ex.Message;

                string jsonResponse = BreadJsonHttpResponseMessageHelper.Create(context, breadResponse);

                await context.Response.WriteAsync(jsonResponse);

                await CopyModifiedBodyStreamToOriginalBodyStreamAsync(modifiedBodyStream, originalBodyStream);
            }
            //finally
            //{             
                //string jsonResponse = BreadJsonHttpResponseMessageHelper.Create(context, breadResponse);

                //await context.Response.WriteAsync(jsonResponse);

                //await CopyModifiedBodyStreamToOriginalBodyStreamAsync(modifiedBodyStream, originalBodyStream);
            //}
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

        private static async Task CopyModifiedBodyStreamToOriginalBodyStreamAsync(MemoryStream modifiedBodyStream, Stream originalBodyStream)
        {
            // with .NET Core we can't modify the original stream, so it has to be copied from the modified stream
            modifiedBodyStream.Seek(0, SeekOrigin.Begin);
            await modifiedBodyStream.CopyToAsync(originalBodyStream);
        }
    }
}
