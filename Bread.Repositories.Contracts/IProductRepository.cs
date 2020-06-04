using Bread.Domain.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Repositories.Contracts
{
    public interface IProductRepository : IGenericBreadRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId);        
    }
}
