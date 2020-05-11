using System.Collections.Generic;

namespace Bread.Services.Contracts
{
    public interface IRestaurantService
    {
        IEnumerable<string> GetAll();
    }
}
