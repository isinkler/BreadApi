using AutoMapper;

using Bread.Common.Options;
using Bread.DataTransfer;
using Bread.FileSystem.Contracts;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using System.IO;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class RestaurantService : GenericBreadService<BLL.Restaurant, DTO.Restaurant>, IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUploadsHandler uploadsHandler;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly StorageOptions storageOptions;

        public RestaurantService(
            IRestaurantRepository restaurantRepository, 
            IUploadsHandler uploadsHandler,
            IOptions<StorageOptions> options,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
        )
            : base(restaurantRepository, mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.uploadsHandler = uploadsHandler;
            this.httpContextAccessor = httpContextAccessor;
            this.storageOptions = options.Value;
        }                

        public async Task AddImageAsync(int id, BreadFile file)
        {
            string imagePath = 
                await uploadsHandler.PersistAsync(storageOptions.UploadsPath + storageOptions.RestaurantUploadsPath, file);

            BLL.Restaurant bllRestaurant = await restaurantRepository.GetAsync(id);
            bllRestaurant.ImagePath = Path.Combine(GetRestaurantImagesUrl(), imagePath).Replace("\\", "/") ;
                       
            await restaurantRepository.UpdateAsync(bllRestaurant);            
        }

        private string GetRestaurantImagesUrl()
        {
            var request = httpContextAccessor.HttpContext.Request;

            return Path.Combine($"{request.Scheme}://{request.Host}", @storageOptions.RestaurantUploadsPath);                    
        }
    }
}
