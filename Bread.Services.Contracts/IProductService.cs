using Bread.DataTransfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId);

        Task<Product> GetAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);
    }
}
