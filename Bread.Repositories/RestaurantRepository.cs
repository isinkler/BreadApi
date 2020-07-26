using AutoMapper;

using Bread.Data;
using Bread.Data.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Linq;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class RestaurantRepository : GenericBreadRepository<DAL.Restaurant, BLL.Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(BreadDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        protected override IQueryable<Restaurant> GetEntities()
        {
            return Context.Restaurants.Include(restaurant => restaurant.Products);
        }
    }
}
