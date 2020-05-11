using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bread.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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