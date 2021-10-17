using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Yatter.Http.Responsive
{
    public class ApiPathNotSetException : Exception
    {
        public ApiPathNotSetException(string message) : base(message) { }

        public ApiPathNotSetException(string message, Exception inner) : base(message, inner) { }
    }
}
