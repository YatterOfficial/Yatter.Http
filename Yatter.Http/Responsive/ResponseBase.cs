using System;
using System.Net;
using Yatter.Invigoration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Yatter.Http.Responsive
{
    public abstract class ResponseBase : IOutcome
    {
        public HttpResponseMessage HttpResponseMessage;
        public abstract void AddHttpResponseMessage(HttpResponseMessage httpResponseMessage);

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
