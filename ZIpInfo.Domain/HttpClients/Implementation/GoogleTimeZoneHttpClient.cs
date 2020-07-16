using System;
using System.Threading.Tasks;
using ZipInfo.Core.HttpClients;
using ZipInfo.Core.Models.ApiModels;
using ZipInfo.Core.Services;
using ZipInfo.Domain.Extensions;

namespace ZipInfo.Domain.HttpClients.Implementation
{
    public class GoogleTimeZoneHttpClient : IGoogleTimeZoneHttpClient
    {
        private readonly string _clientName = "googletimezone";
        private readonly IHttpBaseClient _httpBaseClient;
        private readonly ISettingsService _settingsService;

        public GoogleTimeZoneHttpClient(IHttpBaseClient httpBaseClient, ISettingsService settingsService)
        {
            _httpBaseClient = httpBaseClient;
            _settingsService = settingsService;
        }

        public async Task<GoogleTimeZoneApiModel> GetInfo(LocationModel location)
        {
            var result = await _httpBaseClient.GetAsync<dynamic>(_clientName, $"timezone/json?location={location.Latitude},{location.Longitude}&timestamp=0&key={_settingsService.GetGoogleTimeZoneApiKey()}");

            if (DynamicExtensions.HasProperty(result, "errorMessage"))
                throw new Exception(result.errorMessage.ToString());

            return new GoogleTimeZoneApiModel()
            {
                TimeZoneId = result.timeZoneId,
                TimeZoneName = result.timeZoneName
            };
        }
    }
}
