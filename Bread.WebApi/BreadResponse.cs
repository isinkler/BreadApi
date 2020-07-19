using Bread.Exceptions;

using System.Runtime.Serialization;

namespace Bread.WebApi
{
    [DataContract]
    public class BreadResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Data { get; set; }

        public BreadResponse(bool isSuccess, string message = null, object result = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = result;            
        }

        public static BreadResponse Create()
        {
            return new BreadResponse(isSuccess: true);
        }

        public static BreadResponse Create(bool success, BreadException breadException)
        {
            return new BreadResponse(isSuccess: success, message: breadException.Message);
        }
    }
}
