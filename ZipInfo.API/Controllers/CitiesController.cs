using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZipInfo.API.ViewModel;
using ZipInfo.Core.Services;

namespace ZipInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IZipInfoService _zipInfoService;

        public CitiesController(IZipInfoService zipInfoService)
        {
            _zipInfoService = zipInfoService;
        }

        [HttpGet("info/zip-code/{zipCode}")]
        public async Task<IActionResult> GetInfoAsync(string zipCode)
        {
            var info = await _zipInfoService.GetInfoAsync(zipCode);
            return Ok((ZipInfoViewModel)info);
        }
    }
}