using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;
using System.Threading.Tasks;

namespace Bread.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<Order> CreateAsync(Order order)
        {
            
        }
    }
}
