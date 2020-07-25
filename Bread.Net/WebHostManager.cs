using Microsoft.AspNetCore.Http;

using System.IO;

namespace Bread.Net
{
    public class WebHostManager : IWebHostManager
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public WebHostManager(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetHostUrl()
        {
            var request = httpContextAccessor.HttpContext.Request;

            return Path.Combine($"{request.Scheme}://{request.Host}");
        }
    }
}
