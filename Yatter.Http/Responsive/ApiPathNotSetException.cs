using System;
namespace Yatter.Http.Responsive
{
    public class ApiPathNotSetException : Exception
    {
        public ApiPathNotSetException(string message) : base(message) { }

        public ApiPathNotSetException(string message, Exception inner) : base(message, inner) { }
    }
}
