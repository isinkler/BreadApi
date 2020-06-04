using Bread.Services.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DTO.Product product)
        {
            DTO.Product result = await productService.CreateAsync(product);

            return Ok(result);
        }
    }
}