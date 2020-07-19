using System;

namespace Bread.Exceptions
{
    public class BreadException : Exception
    {        
        public BreadException(string message) : base(message)
        {            
        }
    }
}
