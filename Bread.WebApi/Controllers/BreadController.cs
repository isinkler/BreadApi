using Microsoft.AspNetCore.Mvc;

namespace Bread.WebApi.Controllers
{
    public abstract class BreadController : ControllerBase
    {

        protected ActionResult Success()
        {
            return new BreadResponse()
            {
                IsSuccess = true
            };            
        }

        protected ActionResult Success(object data)
        {
            return new BreadResponse()
            {
                IsSuccess = true,
                Data = data
            };            
        }
    }
}
