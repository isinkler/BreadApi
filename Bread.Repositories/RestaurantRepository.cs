using AutoMapper;

using Bread.Data;
using Bread.Repositories.Contracts;

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
        
    }
}
