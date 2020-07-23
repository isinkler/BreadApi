using Bread.DataTransfer;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Bread.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]    
    public class UsersController : BreadController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Authentication authentication)
        {
            var result = await userService.LoginAsync(authentication);

            return Success(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] User user)
        {
            var result = await userService.RegisterAsync(user);

            return Success(result);
        }
    }
}