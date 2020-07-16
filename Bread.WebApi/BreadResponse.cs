using System.Net;
using System.Runtime.Serialization;

namespace Bread.WebApi
{
    [DataContract]
    public class BreadResponse
    {
        [DataMember]
        public int HttpStatusCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiError ResponseException { get; set; }

        public BreadResponse(HttpStatusCode httpStatusCode, string message = "", object result = null, ApiError apiError = null)
        {
            HttpStatusCode = (int)httpStatusCode;
            Message = message;
            Result = result;
            this.ResponseException = apiError;
        }

        public static BreadResponse Create(HttpStatusCode httpStatusCode)
        {
            return new BreadResponse(httpStatusCode);
        }
    }
}
