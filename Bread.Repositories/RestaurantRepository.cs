using Bread.Repositories.Contracts;

using System.Collections.Generic;

namespace Bread.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public IEnumerable<string> GetAll()
        {
            return new List<string> { "yo, yoooo" };
        }
    }
}
