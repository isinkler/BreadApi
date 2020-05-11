using Bread.Services.Contracts;

using System.Collections.Generic;

namespace Bread.Services
{
    public class RestaurantService : IRestaurantService
    {
        public IEnumerable<string> GetAll()
        {
            return new List<string> { "Restaurant1", "Restaurant2" };
        }
    }
}
