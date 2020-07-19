using Microsoft.AspNetCore.Mvc;

namespace Bread.WebApi.Controllers
{
    public abstract class BreadController : ControllerBase
    {

        protected ActionResult Success()
        {
            var breadResponse = new BreadResponse(true, null, null);

            return breadResponse;
        }

        protected ActionResult Success(object value)
        {
            var breadResponse = new BreadResponse(true, null, value);
            
            return breadResponse;
        }
    }
}
