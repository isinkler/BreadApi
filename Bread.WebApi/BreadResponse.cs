using Bread.Exceptions;

using System.Runtime.Serialization;

namespace Bread.WebApi
{
    [DataContract]
    public class BreadResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Data { get; set; }

        public BreadResponse(bool isSuccess = true, string message = "", object result = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = result;            
        }

        public static BreadResponse Create(bool success, BreadException breadException)
        {
            return new BreadResponse(isSuccess: success, message: breadException.Message);
        }
    }
}
