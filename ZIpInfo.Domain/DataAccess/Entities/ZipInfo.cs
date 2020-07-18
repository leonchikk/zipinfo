using System;

namespace ZipInfo.Domain.DataAccess.Entities
{
    public class ZipInfo
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public double TemperatureInCelsius { get; set; }
        public string TimeZoneName { get; set; }
        public string TimeZoneId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
