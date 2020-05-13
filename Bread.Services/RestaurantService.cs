using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public Task<IEnumerable<string>> GetAllAsync()
        {
            return restaurantRepository.GetAllAsync();
        }
    }
}
