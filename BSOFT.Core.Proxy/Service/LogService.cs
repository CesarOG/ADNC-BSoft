using BSOFT.Core.Proxy.Infraestructure;
using BSOFT.Core.Proxy.ViewObject;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BSOFT.Core.Proxy.Service
{
   public class LogService : ILogService
    {
        private IHttpClient _apiClient;
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly string _remoteServiceBaseUrl;

        public LogService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = $"{settings.Value.LogUrl}";
            _settings = settings;
            _apiClient = httpClient;
        }

        public async Task<bool> Error(string message)
        {
            var uri = ApiPaths.Log.AddLog(_remoteServiceBaseUrl);
            LogRequest logRequest = new LogRequest()
            {
                Message = message,
                IsError = true
            };
            var response = await _apiClient.PostAsync(uri, logRequest);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> Info(string message)
        {
            var uri = ApiPaths.Log.AddLog(_remoteServiceBaseUrl);
            LogRequest logRequest = new LogRequest()
            {
                Message = message,
                IsError = false
            };
            var response = await _apiClient.PostAsync(uri, logRequest);
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
