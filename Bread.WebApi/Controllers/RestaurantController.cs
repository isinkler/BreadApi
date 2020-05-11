using Bread.Services.Contracts;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace Bread.WebApi.Controllers
{
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
        public IEnumerable<string> GetAll()
        {
            return restaurantService.GetAll();
        }
    }
}