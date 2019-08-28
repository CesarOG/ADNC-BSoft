using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.Configuration
{
    public  class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;
        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int MaxTrys => int.Parse(_configuration.GetSection("Polly:Maxtrys").Value);

        public int SecondToWay => int.Parse(_configuration.GetSection("Polly:TimeDelay").Value);
    }
}
