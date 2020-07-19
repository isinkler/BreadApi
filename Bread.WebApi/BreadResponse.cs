using Bread.Exceptions;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Bread.WebApi
{
    [DataContract]
    public class BreadResponse : ActionResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember]
        public object Data { get; set; }

        public BreadResponse(bool isSuccess, string message = null, object value = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = value;            
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {

            var json = new JsonResult(this, JsonSerializerSettings());

            return json.ExecuteResultAsync(context);
        }

        public static BreadResponse Create()
        {
            return new BreadResponse(isSuccess: true);
        }

        public static BreadResponse Create(bool success, BreadException breadException)
        {
            return new BreadResponse(isSuccess: success, message: breadException.Message);
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
