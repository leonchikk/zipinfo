using System.Threading.Tasks;
using ZipInfo.Core.Models.ApiModels;

namespace ZipInfo.Core.HttpClients
{
    public interface IOpenWeatherMapHttpClient
    {
        Task<OpenWeatherApiModel> GetInfoAsync(string zipCode);
    }
}
