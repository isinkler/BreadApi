using Bread.Domain.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;

namespace Bread.Repositories.Contracts
{
    public interface IProductRepository : IGenericBreadRepository<BLL.Product>
    {
        Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId);        
    }
}
