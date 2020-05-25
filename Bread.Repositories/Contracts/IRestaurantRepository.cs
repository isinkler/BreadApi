using Bread.Domain.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;

namespace Bread.Repositories.Contracts
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetAsync(int id);

        Task<IEnumerable<BLL.Restaurant>> GetAllAsync();

        Task<BLL.Restaurant> CreateAsync(BLL.Restaurant restaurant);

        Task<BLL.Restaurant> UpdateAsync(Restaurant restaurant);
    }
}
