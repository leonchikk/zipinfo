using System;
using System.Threading.Tasks;
using ZipInfo.Core.HttpClients;
using ZipInfo.Core.Models.ApiModels;
using ZipInfo.Core.Services;
using ZipInfo.Domain.Extensions;

namespace ZipInfo.Domain.HttpClients.Implementation
{
    public class OpenWeatherMapHttpClient : IOpenWeatherMapHttpClient
    {
        private readonly string _clientName = "openwheather";
        private readonly IHttpBaseClient _httpBaseClient;
        private readonly ISettingsService _settingsService;

        public OpenWeatherMapHttpClient(IHttpBaseClient httpBaseClient, ISettingsService settingsService)
        {
            _httpBaseClient = httpBaseClient;
            _settingsService = settingsService;

        }
        public async Task<OpenWeatherApiModel> GetInfoAsync(string zipCode)
        {
            var result = await _httpBaseClient.GetAsync<dynamic>(_clientName, $"weather?zip={zipCode}&units=metric&appid={_settingsService.GetOpenWeatherMapApiKey()}");

            if (DynamicExtensions.HasProperty(result, "message"))
            {
                var errorMessage = result.message.ToString();
                throw new Exception(errorMessage);
            }

            return new OpenWeatherApiModel()
            {
                CityName = result.name,
                TemperatureInCelsius = result.main.temp,
                Location = new LocationModel()
                {
                    Latitude = result.coord.lat,
                    Longitude = result.coord.lon
                }
            };
        }
    }
}
