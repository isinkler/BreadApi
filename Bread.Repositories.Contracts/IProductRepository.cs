using Bread.Domain.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId);

        Task<Product> GetAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);
    }
}
