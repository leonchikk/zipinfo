using System.Threading.Tasks;
using ZipInfo.Core.Models.ApiModels;

namespace ZipInfo.Core.HttpClients
{
    public interface IGoogleTimeZoneHttpClient
    {
        Task<GoogleTimeZoneApiModel> GetInfo(LocationModel location);
    }
}
