using Bread.Common.Extensions;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.IO;
using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]    
    public class RestaurantsController : BreadController
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

            return Success(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await restaurantService.GetAsync(id);

            return Success(result);
        }

        [HttpPost]       
        public async Task<IActionResult> CreateAsync([FromBody] DTO.Restaurant restaurant)
        {
            var result = await restaurantService.CreateAsync(restaurant);

            return Success(result);
        }

        [HttpPost("{id}/banner")]            
        public async Task<IActionResult> CreateBannerAsync(int id, [BindRequired] IFormFile file)
        {
            if (!file.IsImage())
            {
                throw new UnsupportedContentTypeException("Uploaded file is not an image file.");
            }            

            byte[] bytes = await file.GetBytesAsync();

            var bannerFile = new DTO.BreadFile()
            {
                Bytes = bytes,
                Extension = Path.GetExtension(file.FileName)
            };

            await restaurantService.CreateBannerAsync(id, bannerFile);

            return Success();
        }
    }
}