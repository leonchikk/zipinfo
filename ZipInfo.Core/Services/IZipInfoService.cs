using System.Threading.Tasks;
using ZipInfo.Core.Models.Dtos;

namespace ZipInfo.Core.Services
{
    public interface IZipInfoService
    {
        Task<ZipInfoDtoModel> GetInfoAsync(string zipCode);
    }
}
