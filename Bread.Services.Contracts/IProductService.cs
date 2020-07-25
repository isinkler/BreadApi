using Bread.DataTransfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services.Contracts
{
    public interface IProductService : IGenericBreadService<Product>
    {
        Task AddImageAsync(int id, BreadFile image);

        Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId);
    }
}
