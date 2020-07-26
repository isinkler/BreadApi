using Bread.Net;

using Microsoft.AspNetCore.Mvc;

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

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var json = new JsonResult(this, JsonSerializerSettingsProvider.SerializerSettings());

            return json.ExecuteResultAsync(context);
        }                
    }
}
