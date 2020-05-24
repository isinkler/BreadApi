using Bread.DataTransfer;

using System.Collections.Generic;
using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.Services.Contracts
{
    public interface IRestaurantService
    {
        Task<DTO.Restaurant> GetAsync(int id);

        Task<IEnumerable<DTO.Restaurant>> GetAllAsync();

        Task<Restaurant> CreateAsync(Restaurant restaurant);

        Task<Restaurant> UpdateAsync(Restaurant restaurant);

        Task<string> UpdateBannerAsync(int id, byte[] restaurantBanner);
    }
}
