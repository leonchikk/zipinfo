using Microsoft.Extensions.Options;
using ZipInfo.Core.Models.Settings;
using ZipInfo.Core.Services;

namespace ZipInfo.Domain.Services.Implementation
{
    public class SettingsService : ISettingsService
    {
        private readonly IOptionsMonitor<ApiKeysSettings> _apiKeysSettings;

        public SettingsService(IOptionsMonitor<ApiKeysSettings> apiKeysSettings)
        {
            _apiKeysSettings = apiKeysSettings;
        }

        public string GetGoogleTimeZoneApiKey()
        {
            return _apiKeysSettings.CurrentValue.GoogleTimeZoneApiKey;
        }

        public string GetOpenWeatherMapApiKey()
        {
            return _apiKeysSettings.CurrentValue.OpenWeatherMapApiKey;
        }
    }
}
