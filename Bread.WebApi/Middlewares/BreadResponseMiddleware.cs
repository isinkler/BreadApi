using Bread.Common.Enumerations;
using Bread.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Extensions;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Bread.WebApi.Middlewares
{
    public class BreadResponseMiddleware
    {
        private readonly RequestDelegate next;

        public BreadResponseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (IsSwagger(context))
                await this.next(context);
            else
            {
                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    try
                    {
                        await next.Invoke(context);

                        if (context.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            var body = await FormatResponse(context.Response);
                            await HandleSuccessRequestAsync(context, body, context.Response.StatusCode);

                        }
                        else
                        {
                            await HandleNotSuccessRequestAsync(context, context.Response.StatusCode);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        await HandleExceptionAsync(context, ex);
                    }
                    finally
                    {
                        responseBody.Seek(0, SeekOrigin.Begin);
                        await responseBody.CopyToAsync(originalBodyStream);
                    }
                }
            }
            
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case BreadException breadException:

                    await HandleBreadException(context, breadException);

                    break;                    
            }

            

            //ApiError apiError = null;
            //BreadResponse apiResponse = null;
            //int code = 0;

            //context.Response.ContentType = "application/json";

            //if (exception is BreadException breadException)
            //{                
            //    apiError = new ApiError(breadException.Message);                
                
            //    code = breadException.StatusCode;
            //    context.Response.StatusCode = code;
            //}            
            //else
            //{
            //    apiError = new ApiError("Something went wrong!");                
            //    code = (int)HttpStatusCode.InternalServerError;
            //    context.Response.StatusCode = code;
            //}


            //apiResponse = new BreadResponse(code, ResponseMessageType.Exception.GetDisplayName(), null, apiError);

            //var json = JsonConvert.SerializeObject(apiResponse);

            //return context.Response.WriteAsync(json);
        }

        private async Task HandleBreadException(HttpContext context, BreadException breadException)
        {
            var response = 
                BreadResponse.Create(breadException.HttpStatusCode ?? HttpStatusCode.InternalServerError);

            string jsonResponse = BreadJsonHttpResponseMessageHelper.Create(response);

            await context.Response.WriteAsync(jsonResponse);            
        }

        private static Task HandleNotSuccessRequestAsync(HttpContext context, int code)
        {
            context.Response.ContentType = "application/json";

            ApiError apiError = null;
            BreadResponse apiResponse = null;

            if (code == (int)HttpStatusCode.NotFound)
                apiError = new ApiError("The specified URI does not exist. Please verify and try again.");
            else if (code == (int)HttpStatusCode.NoContent)
                apiError = new ApiError("The specified URI does not contain any content.");
            else
                apiError = new ApiError("Your request cannot be processed. Please contact a support.");

            apiResponse = new BreadResponse((HttpStatusCode) code, ResponseMessageType.Failure.GetDisplayName(), null);
            context.Response.StatusCode = code;

            var json = JsonConvert.SerializeObject(apiResponse);

            return context.Response.WriteAsync(json);
        }

        private static Task HandleSuccessRequestAsync(HttpContext context, object body, int code)
        {
            context.Response.ContentType = "application/json";
            string jsonString, bodyText = string.Empty;
            BreadResponse apiResponse = null;


            
            bodyText = JsonConvert.SerializeObject(body);
            

            dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);
            Type type;

            type = bodyContent?.GetType();

            if (type.Equals(typeof(Newtonsoft.Json.Linq.JObject)))
            {
                apiResponse = JsonConvert.DeserializeObject<BreadResponse>(bodyText);
                if (apiResponse.HttpStatusCode != code)
                    jsonString = JsonConvert.SerializeObject(apiResponse);
                else if (apiResponse.Result != null)
                    jsonString = JsonConvert.SerializeObject(apiResponse);
                else
                {
                    apiResponse = new BreadResponse((HttpStatusCode)code, ResponseMessageType.Success.GetDisplayName(), bodyContent);
                    jsonString = JsonConvert.SerializeObject(apiResponse);
                }
            }
            else
            {
                apiResponse = new BreadResponse((HttpStatusCode)code, ResponseMessageType.Success.GetDisplayName(), bodyContent);
                jsonString = JsonConvert.SerializeObject(apiResponse);
            }

            return context.Response.WriteAsync(jsonString);
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");

        }
    }
}
