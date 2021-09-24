using System;
using System.Net.Http;
using System.Threading.Tasks;
using Yatter.Http;
using Yatter.Http.Responsive;

namespace Yatter.Http.Clients
{
    public interface IResponsiveHttpClient
    {
        void OverrideDefaultHttpMessageHandler(HttpMessageHandler handler);
        Task<TResponse> GetAsync<TResponse, TRequest>(TRequest request) where TRequest : RequestBase, new() where TResponse : ResponseBase, new();
    }
}
