using AutoMapper;

using Bread.Common.Options;
using Bread.DataTransfer;
using Bread.FileSystem.Contracts;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using Microsoft.Extensions.Options;

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
        private readonly StorageOptions storageOptions;

        public RestaurantService(
            IRestaurantRepository restaurantRepository, 
            IUploadsHandler uploadsHandler,
            IOptions<StorageOptions> options,
            IMapper mapper
        )
            :base(mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.uploadsHandler = uploadsHandler;
            this.storageOptions = options.Value;
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            BLL.Restaurant restaurant = await restaurantRepository.GetAsync(id);

            var result = Mapper.Map<DTO.Restaurant>(restaurant);

            return result;
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

        public async Task<DTO.Restaurant> UpdateAsync(DTO.Restaurant restaurant)
        {
            var bllRestaurant = Mapper.Map<BLL.Restaurant>(restaurant);

            bllRestaurant = await restaurantRepository.UpdateAsync(bllRestaurant);

            restaurant = Mapper.Map<DTO.Restaurant>(bllRestaurant);

            return restaurant;
        }

        public async Task CreateBannerAsync(int id, byte[] bytes)
        {
            string bannerPath = await uploadsHandler.PersistAsync(storageOptions.RestaurantUploadsPath, bytes);

            BLL.Restaurant bllRestaurant = await restaurantRepository.GetAsync(id);
            bllRestaurant.BannerPath = bannerPath;

            await restaurantRepository.UpdateAsync(bllRestaurant);            
        }        
    }
}
