﻿using System;
using System.Net;
using System.Net.Http;
using Yatter.Invigoration;

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
