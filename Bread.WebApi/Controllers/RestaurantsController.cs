using Bread.Common.Extensions;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;        

        public RestaurantsController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await restaurantService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]       
        public async Task<IActionResult> CreateAsync([FromBody] DTO.Restaurant restaurant)
        {
            var result = await restaurantService.CreateAsync(restaurant);

            return Ok(result);
        }

        [HttpPost("{id}/banner")]                
        public async Task<IActionResult> CreateBannerAsync(int id, IFormFile file)
        {
            byte[] bytes = await file.GetBytesAsync();            

            await restaurantService.CreateBannerAsync(id, bytes);

            return Ok();
        }
    }
}