using AutoMapper;

using Bread.Common.Options;
using Bread.DataTransfer;
using Bread.FileSystem.Contracts;
using Bread.Net;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

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
        private readonly IWebHostManager webHostManager;       
        private readonly StorageOptions storageOptions;

        public RestaurantService(
            IRestaurantRepository restaurantRepository, 
            IUploadsHandler uploadsHandler,
            IOptions<StorageOptions> options,
            IWebHostManager webHostManager,
            IMapper mapper
        )
            : base(restaurantRepository, mapper)
        {
            this.restaurantRepository = restaurantRepository;
            this.uploadsHandler = uploadsHandler;
            this.webHostManager = webHostManager;            
            this.storageOptions = options.Value;
        }                

        public async Task AddImageAsync(int id, BreadFile image)
        {
            BLL.Restaurant bllRestaurant = await restaurantRepository.GetAsync(id);

            string restaurantPath = Path.Combine(storageOptions.RestaurantUploadsAbsolutePath, bllRestaurant.Name);

            string imagePath = 
                await uploadsHandler.PersistAsync(restaurantPath, image);

            bllRestaurant.ImagePath = Path.Combine(GetRestaurantUploadsUrl(), imagePath).Replace("\\", "/") ;
                       
            await restaurantRepository.UpdateAsync(bllRestaurant);            
        }

        private string GetRestaurantUploadsUrl()
        {            
            return Path.Combine(webHostManager.GetHostUrl(), @storageOptions.RestaurantUploadsRelativePath);                    
        }
    }
}
