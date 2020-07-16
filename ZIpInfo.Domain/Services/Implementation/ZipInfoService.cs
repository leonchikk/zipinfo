using System;
using System.Threading.Tasks;
using ZipInfo.Core.HttpClients;
using ZipInfo.Core.Models.Dtos;
using ZipInfo.Core.Services;

namespace ZipInfo.Domain.Services.Implementation
{
    public class ZipInfoService : IZipInfoService
    {
        private readonly IGoogleTimeZoneHttpClient _googleTimeZoneClient;
        private readonly IOpenWeatherMapHttpClient _openWeatherMapClient;

        public ZipInfoService(
            IGoogleTimeZoneHttpClient googleTimeZoneClient,
            IOpenWeatherMapHttpClient openWeatherMapClient
        )
        {
            _googleTimeZoneClient = googleTimeZoneClient;
            _openWeatherMapClient = openWeatherMapClient;
        }

        public async Task<ZipInfoDtoModel> GetInfoAsync(string zipCode)
        {
            var infoFromOpenWeather = await _openWeatherMapClient.GetInfoAsync(zipCode);
            var infoFromGoogleTimeZone = await _googleTimeZoneClient.GetInfo(infoFromOpenWeather.Location);

            return new ZipInfoDtoModel()
            {
                City = infoFromOpenWeather.CityName,
                TemperatureInCelsius = infoFromOpenWeather.TemperatureInCelsius,
                TimeZoneName = infoFromGoogleTimeZone.TimeZoneName,
                TimeZoneId = infoFromGoogleTimeZone.TimeZoneId
            };
        }
    }
}
