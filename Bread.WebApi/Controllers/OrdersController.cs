using Bread.DataTransfer;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> CreateAsync([FromBody] DTO.Order order)
        {
            Order result = await orderService.CreateAsync(order);

            return Ok(result);
        }
    }
}