using Bread.Data;
using Bread.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.Repositories
{
    public class RestaurantRepository : BreadRepository, IRestaurantRepository
    {
        public RestaurantRepository(BreadDbContext dbContext) : base(dbContext)
        {

        }        

        public async Task<IEnumerable<string>> GetAllAsync()
        {
            IQueryable<Restaurant> entities = Context.Restaurants;

            List<Restaurant> result = await entities.ToListAsync();

            return result.Select(r => r.Name);
        }
    }
}
