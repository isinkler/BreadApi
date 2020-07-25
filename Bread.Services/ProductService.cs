using AutoMapper;

using Bread.Common.Options;
using Bread.DataTransfer;
using Bread.FileSystem.Contracts;
using Bread.Net;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class ProductService : GenericBreadService<BLL.Product, DTO.Product>, IProductService
    {
        private const string ProductsFolderName = "products";

        private readonly IProductRepository productRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUploadsHandler uploadsHandler;
        private readonly IWebHostManager webHostManager;
        private readonly StorageOptions storageOptions;

        public ProductService(
            IProductRepository productRepository,
            IRestaurantRepository restaurantRepository,
            IUploadsHandler uploadsHandler,
            IOptions<StorageOptions> options,
            IWebHostManager webHostManager,
            IMapper mapper
        ) 
            : base(productRepository, mapper)
        {
            this.productRepository = productRepository;
            this.restaurantRepository = restaurantRepository;
            this.uploadsHandler = uploadsHandler;
            this.webHostManager = webHostManager;
            this.storageOptions = options.Value;
        }

        public Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddImageAsync(int id, BreadFile image)
        {
            BLL.Product bllProduct = await productRepository.GetAsync(id);

            if (bllProduct == null)
            {
                return;
            }

            BLL.Restaurant bllRestaurant = await restaurantRepository.GetAsync(bllProduct.RestaurantId);

            string productsPath = Path.Combine(storageOptions.RestaurantUploadsAbsolutePath, bllRestaurant.Name, ProductsFolderName);

            string imagePath =
                await uploadsHandler.PersistAsync(productsPath, image);

            bllProduct.ImagePath = Path.Combine(GetRestaurantUploadsUrl(bllRestaurant.Name), imagePath).Replace("\\", "/");

            await productRepository.UpdateAsync(bllProduct);
        }

        private string GetRestaurantUploadsUrl(string restaurantName)
        {
            return Path.Combine(webHostManager.GetHostUrl(), @storageOptions.RestaurantUploadsRelativePath, restaurantName, ProductsFolderName);
        }
    }
}
