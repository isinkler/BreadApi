using System;
using System.Net;

namespace Bread.Exceptions
{
    public class BreadException : Exception
    {
        public HttpStatusCode? HttpStatusCode { get; set; }

        public BreadException(string message, HttpStatusCode? httpStatusCode) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}
