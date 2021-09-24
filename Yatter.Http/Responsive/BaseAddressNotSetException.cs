using System;
namespace Yatter.Http.Responsive
{
    public class BaseAddressNotSetException : Exception
    {
        public BaseAddressNotSetException(string message) : base(message) { }

        public BaseAddressNotSetException(string message, Exception inner) : base(message, inner) { }
    }
}
