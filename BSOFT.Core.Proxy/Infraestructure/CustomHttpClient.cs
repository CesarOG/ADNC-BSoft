using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSOFT.Core.Proxy.Infraestructure
{
   public class CustomHttpClient : IHttpClient
    {
        private HttpClient _client;

        public CustomHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
        {
            return await DoPostPutAsync(HttpMethod.Post, uri, item);
        }

        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, T item)
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                throw new ArgumentException("Value must be either post or put.", nameof(method));
            }
            var requestMessage = new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")
            };
            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }
            return response;
        }
    }
}
