using AutoMapper;

using Bread.Common.Enumerations;
using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class OrderService : GenericBreadService<BLL.Order, DTO.Order>, IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper) 
            : base(orderRepository, mapper)
        {
            this.orderRepository = orderRepository;
        }

        public async override Task<Order> CreateAsync(DTO.Order order)
        {
            var bllOrder = new BLL.Order()
            {
                PaymentType = order.PaymentType,
                Status = OrderStatus.Placed,
                UserId = order.UserId             
            };

            bllOrder = await orderRepository.CreateAsync(bllOrder);

            bllOrder.ProductOrders = new List<BLL.ProductOrder>();
            foreach(var productOrder in order.ProductOrders)
            {
                bllOrder.ProductOrders.Add(new BLL.ProductOrder()
                {
                    OrderId = bllOrder.Id,
                    ProductId = productOrder.ProductId
                });
            }

            bllOrder = await orderRepository.UpdateAsync(bllOrder);

            // ?
            return null;
        }
    }
}
