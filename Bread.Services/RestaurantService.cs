using AutoMapper;

using Bread.FileSystem.Contracts;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class RestaurantService : BreadService, IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUploadsHandler uploadsHandler;

        public RestaurantService(
            IRestaurantRepository restaurantRepository, 
            IUploadsHandler uploadsHandler,
            IMapper mapper
        )
            :base(mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.uploadsHandler = uploadsHandler;
        }

        public async Task<IEnumerable<DTO.Restaurant>> GetAllAsync()
        {
            IEnumerable<BLL.Restaurant> restaurants = await restaurantRepository.GetAllAsync();

            var result = Mapper.Map<IEnumerable<DTO.Restaurant>>(restaurants);

            return result;
        }

        public async Task<DTO.Restaurant> CreateAsync(DTO.Restaurant restaurant)
        {
            var bllRestaurant = Mapper.Map<BLL.Restaurant>(restaurant);

            bllRestaurant = await restaurantRepository.CreateAsync(bllRestaurant);

            restaurant = Mapper.Map<DTO.Restaurant>(bllRestaurant);

            return restaurant;
        }

        public async Task<string> UpdateBannerAsync(byte[] bytes)
        {
            string bannerPath = await uploadsHandler.PersistAsync(bytes);

            return bannerPath;
        }
    }
}
