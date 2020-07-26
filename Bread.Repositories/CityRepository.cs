using AutoMapper;

using Bread.Data;
using Bread.Data.Models;
using Bread.Repositories.Contracts;

using System.Linq;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class CityRepository : GenericBreadRepository<DAL.City, BLL.City>, ICityRepository
    {
        public CityRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override IQueryable<City> GetEntities()
        {
            throw new System.NotImplementedException();
        }
    }
}
