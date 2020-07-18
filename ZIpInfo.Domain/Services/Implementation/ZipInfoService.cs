using System;
using System.Linq;
using System.Threading.Tasks;
using ZipInfo.Core.HttpClients;
using ZipInfo.Core.Models.Dtos;
using ZipInfo.Core.Services;
using ZipInfo.Domain.DataAccess;

namespace ZipInfo.Domain.Services.Implementation
{
    public class ZipInfoService : IZipInfoService
    {
        private readonly IGoogleTimeZoneHttpClient _googleTimeZoneClient;
        private readonly IOpenWeatherMapHttpClient _openWeatherMapClient;
        private readonly ZIpInfoContext _dbContext;
        private const int _delay = 60;

        public ZipInfoService(
            IGoogleTimeZoneHttpClient googleTimeZoneClient,
            IOpenWeatherMapHttpClient openWeatherMapClient,
            ZIpInfoContext dbContext
        )
        {
            _googleTimeZoneClient = googleTimeZoneClient;
            _openWeatherMapClient = openWeatherMapClient;
            _dbContext = dbContext;
        }

        public async Task<ZipInfoDtoModel> GetInfoAsync(string zipCode)
        {
            var zipInfo = _dbContext.ZipInfos.OrderByDescending(x => x.CreatedAt).FirstOrDefault(x => x.ZipCode == zipCode);

            if (zipInfo != null)
            {
                var currentTime = DateTime.UtcNow;
                var createdAt = zipInfo.CreatedAt;

                if ((currentTime - createdAt).TotalSeconds <= _delay)
                {
                    return new ZipInfoDtoModel()
                    {
                        City = zipInfo.City + " (Stored in DB)",
                        TemperatureInCelsius = zipInfo.TemperatureInCelsius,
                        TimeZoneId = zipInfo.TimeZoneId,
                        TimeZoneName = zipInfo.TimeZoneName
                    };
                }
            }

            var zipInfoResponse = await GetZipInfoFromApiAsync(zipCode);
            _dbContext.ZipInfos.Add(new DataAccess.Entities.ZipInfo()
            {
                City = zipInfoResponse.City,
                ZipCode = zipCode,
                TemperatureInCelsius = zipInfoResponse.TemperatureInCelsius,
                TimeZoneId = zipInfoResponse.TimeZoneId,
                TimeZoneName = zipInfoResponse.TimeZoneName,
                CreatedAt = DateTime.UtcNow
            });

            await _dbContext.SaveChangesAsync();
            return zipInfoResponse;
        }

        private async Task<ZipInfoDtoModel> GetZipInfoFromApiAsync(string zipCode)
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
