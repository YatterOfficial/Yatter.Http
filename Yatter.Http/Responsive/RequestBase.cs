using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Yatter.Http.Responsive
{
    public abstract class RequestBase
    {
        /// <summary>
        /// The Base Address of the internal HttpClient
        /// </summary>
        public Uri BaseAddress { get; protected set; }
        /// <summary>
        /// The ApiPath of the GetAsync(path) call of the internal HttpClient
        /// </summary>
        public string ApiPath { get; protected set; }
        /// <summary>
        /// HttpContent for POST operations
        /// </summary>
        public HttpContent HttpContent { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client">The method of adding the internal HttpClient of the ResponsiveHttpClient so that when overriding this function, that such things as the Default Headers can be accessed.</param>
        public virtual void AddClient(HttpClient client) { }
        /// <summary>
        /// Shall the internal HttpClient of the ResponsiveHttpClient be added so that 
        /// </summary>
        public bool IsAddClient { get; set; }
    }
}
