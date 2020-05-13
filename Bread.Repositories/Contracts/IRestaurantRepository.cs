using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Repositories.Contracts
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<string>> GetAllAsync();
    }
}
