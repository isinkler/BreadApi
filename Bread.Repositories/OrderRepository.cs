using AutoMapper;

using Bread.Data;
using Bread.Repositories.Contracts;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class OrderRepository : GenericBreadRepository<DAL.Order, BLL.Order>, IOrderRepository
    {
        public OrderRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }        
    }
}
