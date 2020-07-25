using Bread.Common.Extensions;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.IO;
using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]    
    public class ProductsController : BreadController
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

        [HttpPost("{id}/image")]
        public async Task<IActionResult> AddImageAsync(int id, [BindRequired] IFormFile file)
        {
            if (!file.IsImage())
            {
                throw new UnsupportedContentTypeException("Uploaded file is not an image file.");
            }

            byte[] bytes = await file.GetBytesAsync();

            var image = new DTO.BreadFile()
            {
                Bytes = bytes,
                Extension = Path.GetExtension(file.FileName)
            };

            await productService.AddImageAsync(id, image);

            return Success();
        }
    }
}