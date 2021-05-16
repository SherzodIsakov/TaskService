using AuthenticationBase.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using System;
using System.Net.Http;

namespace TaskService.Client.Configuration
{
    public static class TextTaskServiceClientConfiguration
    {
        public static IServiceCollection AddTaskServiceClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddTransient(_ => RestService.For<ITaskClient>(
                new HttpClient
                (
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true }
                )
                {
                    BaseAddress = new Uri(configuration["ServiceUrls:TaskService"]),
                    Timeout = TimeSpan.FromMinutes(5)
                }));

            return services;
        }
        public static IServiceCollection AddTaskServiceTokenClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiClient<ITaskClient>(configuration, new RefitSettings(), "ServiceUrls:TaskService");

            return services;
        }
    }
}
