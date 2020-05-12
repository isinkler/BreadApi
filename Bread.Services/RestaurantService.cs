using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;

namespace Bread.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public IEnumerable<string> GetAll()
        {
            return restaurantRepository.GetAllAsync();
        }
    }
}
