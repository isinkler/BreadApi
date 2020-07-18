using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bread.WebApi
{
    public class BreadJsonHttpResponseMessageHelper
    {
        private const string ContentTypeJson = "application/json";

        public static string Create(HttpContext context, BreadResponse response)
        {
            context.Response.ContentType = ContentTypeJson;

            string jsonResponse = JsonConvert.SerializeObject(response, JsonSerializerSettings());

            return jsonResponse;
        }

        private static JsonSerializerSettings JsonSerializerSettings()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
        }
    }
}
