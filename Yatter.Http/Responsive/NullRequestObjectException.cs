using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Yatter.Http.Responsive
{
    public class NullRequestObjectException : Exception
    {
        public NullRequestObjectException(string message) : base(message) { }

        public NullRequestObjectException(string message, Exception inner) : base(message, inner) { }
    }
}
