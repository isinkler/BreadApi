using Bread.DataTransfer;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]   
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DTO.Order order)
        {
            Order result = await orderService.CreateAsync(order);

            return Ok(result);
        }
    }
}