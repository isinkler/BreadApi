using Bread.DataTransfer;

using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.Services.Contracts
{
    public interface IRestaurantService
    {
        Task<IEnumerable<DTO.Restaurant>> GetAllAsync();

        Task<Restaurant> CreateAsync(Restaurant restaurant);

        Task<Restaurant> UpdateBannerAsync(IFormFile restaurantBanner);
    }
}
