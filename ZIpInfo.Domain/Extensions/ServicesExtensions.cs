using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZipInfo.Core.HttpClients;
using ZipInfo.Core.Models.Settings;
using ZipInfo.Core.Services;
using ZipInfo.Domain.HttpClients.Implementation;
using ZipInfo.Domain.Services.Implementation;

namespace ZipInfo.Domain.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var apiKeySettings = configuration.GetSection("ApiKeysSettings");
            services.Configure<ApiKeysSettings>(apiKeySettings);
            services.AddSingleton<ISettingsService, SettingsService>();

            return services;
        }

        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpBaseClient, HttpBaseClient>();
            services.AddScoped<IGoogleTimeZoneHttpClient, GoogleTimeZoneHttpClient>();
            services.AddScoped<IOpenWeatherMapHttpClient, OpenWeatherMapHttpClient>();

            services.AddHttpClient("openwheather", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("ApiUrlsSettings:OpenWeatherMapApiUrl").Value);
            });

            services.AddHttpClient("googletimezone", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("ApiUrlsSettings:GoogleTimeZoneApiUrl").Value);
            });

            return services;
        }

        public static IServiceCollection AddZipInfoService(this IServiceCollection services)
        {
            services.AddScoped<IZipInfoService, ZipInfoService>();

            return services;
        }
    }
}
