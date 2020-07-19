using Bread.Net;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace Bread.WebApi
{
    public class BreadJsonHttpResponseMessageHelper
    {
        private const string ContentTypeJson = "application/json";

        public static string Create(HttpContext context, BreadResponse response)
        {
            context.Response.ContentType = ContentTypeJson;

            string jsonResponse = 
                JsonConvert.SerializeObject(response, JsonSerializerSettingsProvider.SerializerSettings());

            return jsonResponse;
        }        
    }
}
