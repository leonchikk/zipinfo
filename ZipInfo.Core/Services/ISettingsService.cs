namespace ZipInfo.Core.Services
{
    public interface ISettingsService
    {
        string GetOpenWeatherMapApiKey();
        string GetGoogleTimeZoneApiKey();
    }
}
