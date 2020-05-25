    using AutoMapper;

using Bread.Common.Extensions;
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

        public async Task<BLL.Restaurant> GetAsync(int id)
        {
            DAL.Restaurant dalRestaurant = 
                await Context.Restaurants.SingleOrDefaultAsync(entity => entity.Id == id);

            var result = Mapper.Map<BLL.Restaurant>(dalRestaurant);

            return result;
        }

        public async Task<IEnumerable<BLL.Restaurant>> GetAllAsync()
        {
            IQueryable<DAL.Restaurant> entitiesQuery = Context.Restaurants;

            List<DAL.Restaurant> entities = await entitiesQuery.ToListAsync();

            var result = Mapper.Map<IEnumerable<BLL.Restaurant>>(entities);

            return result;
        }

        public async Task<BLL.Restaurant> CreateAsync(BLL.Restaurant restaurant)
        {
            var dalRestaurant = Mapper.Map<DAL.Restaurant>(restaurant);

            await Context.Restaurants.AddAsync(dalRestaurant);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<BLL.Restaurant>(dalRestaurant);

            return result;
        }

        public async Task<BLL.Restaurant> UpdateAsync(BLL.Restaurant restaurant)
        {
            DAL.Restaurant dalRestaurant = 
                await Context.Restaurants.SingleOrDefaultAsync(entity => entity.Id == restaurant.Id);

            dalRestaurant.ThrowIfNull(nameof(dalRestaurant));

            Mapper.Map(dalRestaurant, restaurant);

            Context.Update(dalRestaurant);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<BLL.Restaurant>(dalRestaurant);

            return result;
        }
    }
}
