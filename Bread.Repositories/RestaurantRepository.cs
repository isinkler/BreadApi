using AutoMapper;

using Bread.Data;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class RestaurantRepository : BreadRepository, IRestaurantRepository
    {
        public RestaurantRepository(BreadDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {

        }        

        public async Task<IEnumerable<BLL.Restaurant>> GetAllAsync()
        {
            IQueryable<DAL.Restaurant> entityQuery = Context.Restaurants;

            List<DAL.Restaurant> entities = await entityQuery.ToListAsync();

            IEnumerable<BLL.Restaurant> result = Mapper.Map<IEnumerable<BLL.Restaurant>>(entities);

            return result;
        }

        public async Task<BLL.Restaurant> CreateAsync(BLL.Restaurant restaurant)
        {
            var dalRestaurant = Mapper.Map<DAL.Restaurant>(restaurant);

            await Context.Restaurants.AddAsync(dalRestaurant);
            await Context.SaveChangesAsync();

            restaurant = Mapper.Map<BLL.Restaurant>(dalRestaurant);

            return restaurant;
        }
    }
}
