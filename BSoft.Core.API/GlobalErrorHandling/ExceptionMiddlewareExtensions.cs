using BSoft.Invoices.API.Configuration;
using BSOFT.Core.Proxy.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BSoft.Core.API.GlobalErrorHandling
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IAppConfig appConfig, ILogService logSvc)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var err = $"Error: {contextFeature.Error.Message}";

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = err
                        }.ToString());

                        var maxTrys = appConfig.MaxTrys;
                        var secondToWay = TimeSpan.FromSeconds(appConfig.SecondToWay);

                        var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(maxTrys, i => secondToWay);

                        await retryPolity.ExecuteAsync(async () =>
                        {
                            await logSvc.Error($"ERROR -> {err}");
                        });

                    }
                });
            });
        }
    }
}
