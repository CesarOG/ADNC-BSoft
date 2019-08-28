using BSoft.Invoices.API.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            return services;
        }

        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAppConfig, AppConfig>();
            return services;
        }
    }
}
