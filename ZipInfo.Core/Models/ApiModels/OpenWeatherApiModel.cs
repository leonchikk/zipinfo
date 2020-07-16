namespace ZipInfo.Core.Models.ApiModels
{
    public class OpenWeatherApiModel
    {
        public string CityName { get; set; }
        public double TemperatureInCelsius { get; set; }
        public LocationModel Location { get; set; }
    }
}
