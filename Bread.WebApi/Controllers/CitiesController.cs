using Bread.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;
        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            DTO.City result = await cityService.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DTO.City city)
        {
            DTO.City result = await cityService.CreateAsync(city);

            return Ok(result);
        }
    }
}
