using ZipInfo.Core.Models.Dtos;

namespace ZipInfo.API.ViewModel
{
    public class ZipInfoViewModel
    {
        public string City { get; set; }
        public double TemperatureInCelsius { get; set; }
        public string TimeZoneName { get; set; }
        public string TimeZoneId { get; set; }
        public string Message { get; set; }

        public static explicit operator ZipInfoViewModel(ZipInfoDtoModel dtoModel)  
        {
            return new ZipInfoViewModel()
            {
                City = dtoModel.City,
                TemperatureInCelsius = dtoModel.TemperatureInCelsius,
                TimeZoneId = dtoModel.TimeZoneId,
                TimeZoneName = dtoModel.TimeZoneName,
                Message = $"At the location {dtoModel.City}, the temperature " +
                          $"is {dtoModel.TemperatureInCelsius} in celsius, and the timezone " +
                          $"is {dtoModel.TimeZoneName}"
            };
        }
    }
}
