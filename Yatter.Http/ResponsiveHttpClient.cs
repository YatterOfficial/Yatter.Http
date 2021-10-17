using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Yatter.Http;
using Yatter.Http.Responsive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Yatter.Http.Clients
{
    public class ResponsiveHttpClient : IResponsiveHttpClient
    {
        private HttpClient client;
        private HttpMessageHandler _handler;

        string GetRequestObjectFullName<T>(T instance) { return typeof(T).FullName; }

        public async Task<TResponse> GetAsync<TResponse, TRequest>(TRequest request)
            where TRequest : RequestBase, new() where TResponse : ResponseBase, new()
        {
            // (1) Check that the conditions exist to progress
            if (request == null) throw new NullRequestObjectException(string.Format("TRequest object is null in {0}", this.GetType()));
            if (request.BaseAddress == null) throw new BaseAddressNotSetException(string.Format("Base Address not set in type {0}", typeof(TRequest)));
            if (request.ApiPath == null) throw new ApiPathNotSetException(string.Format("API Path not set in type {0}", typeof(TRequest)));

            // (2) Add the HttpMessageHandler if the default one is to be overridden
            if (_handler == null)
            {
                client = new HttpClient();
            }
            else
            {
                client = new HttpClient(_handler);
            }

            // (3) Set the BaseAddress of the HttpClient
            client.BaseAddress = request.BaseAddress;


            // (4) Allow the HttpClient's DefaultRequestHeaders to be configured

            if (typeof(TRequest).GetTypeInfo().GetDeclaredMethod("AddClient") != null) // i.e. If the TRequest object has overridden the RequestBase method 'AddClient', for example, so that it could configure the DefaultRequestHeaders, then add the HttpClient to the TRequest object!
            {
                request.AddClient(client);
            }

            // (5) Make the Http request
            var httpResponseMessage = await client.GetAsync(request.ApiPath);


            // (5) Prepare the TResponse object so that it can be returned with the httpResponse
            TResponse response = default(TResponse);

            response = new TResponse();

            response.StatusCode = httpResponseMessage.StatusCode;
            response.IsSuccess = httpResponseMessage.IsSuccessStatusCode;
            if (!response.IsSuccess)
            {
                response.Message = httpResponseMessage.ReasonPhrase;
            }

            response.AddHttpResponseMessage(httpResponseMessage);

            // (6) Return TResponse object
            return response;
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest request)
            where TRequest : RequestBase, new() where TResponse : ResponseBase, new()
        {
            // (1) Check that the conditions exist to progress
            if (request == null) throw new NullRequestObjectException(string.Format("TRequest object is null in {0}", this.GetType()));
            if (request.BaseAddress == null) throw new BaseAddressNotSetException(string.Format("Base Address not set in type {0}", typeof(TRequest)));
            if (request.ApiPath == null) throw new ApiPathNotSetException(string.Format("API Path not set in type {0}", typeof(TRequest)));

            // (2) Add the HttpMessageHandler if the default one is to be overridden
            if (_handler == null)
            {
                client = new HttpClient();
            }
            else
            {
                client = new HttpClient(_handler);
            }

            // (3) Set the BaseAddress of the HttpClient
            client.BaseAddress = request.BaseAddress;


            // (4) Allow the HttpClient's DefaultRequestHeaders and HttpContent to be configured

            if (typeof(TRequest).GetTypeInfo().GetDeclaredMethod("AddClient") != null) // i.e. If the TRequest object has overridden the RequestBase method 'AddClient', for example, so that it could configure the DefaultRequestHeaders, then add the HttpClient to the TRequest object!
            {
                request.AddClient(client);
            }

            // (5) Make the Http request
            var httpResponseMessage = await client.PostAsync(request.ApiPath, request.HttpContent);


            // (5) Prepare the TResponse object so that it can be returned with the httpResponse
            TResponse response = default(TResponse);

            response = new TResponse();

            response.StatusCode = httpResponseMessage.StatusCode;
            response.IsSuccess = httpResponseMessage.IsSuccessStatusCode;
            if (!response.IsSuccess)
            {
                response.Message = httpResponseMessage.ReasonPhrase;
            }

            response.AddHttpResponseMessage(httpResponseMessage);

            // (6) Return TResponse object
            return response;
        }

        public void OverrideDefaultHttpMessageHandler(HttpMessageHandler handler)
        {
            _handler = handler;
        }
    }
}
