using System.Collections.Generic;

namespace Bread.Repositories.Contracts
{
    public interface IRestaurantRepository
    {
        IEnumerable<string> GetAllAsync();
    }
}
