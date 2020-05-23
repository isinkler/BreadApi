using Bread.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IEnumerable<DTO.Restaurant>> GetAll()
        {
            return await restaurantService.GetAllAsync();
        }

        [HttpPost]
        public async Task<DTO.Restaurant> CreateAsync([FromBody] DTO.Restaurant restaurant)
        {
            return await restaurantService.CreateAsync(restaurant);
        }
    }
}