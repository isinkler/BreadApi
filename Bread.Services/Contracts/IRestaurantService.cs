using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services.Contracts
{
    public interface IRestaurantService
    {
        Task<IEnumerable<string>> GetAllAsync();
    }
}
