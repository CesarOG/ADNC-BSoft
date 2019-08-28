using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSOFT.Core.Proxy.Infraestructure
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> PostAsync<T>(string uri, T item);
    }
}
