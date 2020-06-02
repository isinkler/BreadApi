using AutoMapper;

using Bread.Common.Extensions;
using Bread.Data;
using Bread.Domain.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class OrderRepository : BreadRepository, IOrderRepository
    {
        public OrderRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Order> CreateAsync(BLL.Order bllOrder)
        {
            var dalOrder = Mapper.Map<DAL.Order>(bllOrder);

            await Context.AddAsync(dalOrder);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<BLL.Order>(dalOrder);

            return result;
        }

        public async Task<Order> UpdateAsync(BLL.Order bllOrder)
        {
            DAL.Order dalOrder =
                await Context.Orders.SingleOrDefaultAsync(order => order.Id == bllOrder.Id);

            dalOrder.ThrowIfNull(nameof(dalOrder));

            Mapper.Map(bllOrder, dalOrder);

            Context.Update(dalOrder);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<BLL.Order>(dalOrder);

            return result;
        }
    }
}
