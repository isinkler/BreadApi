using AutoMapper;

using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class ProductService : GenericBreadService<BLL.Product, DTO.Product>, IProductService
    {
        public ProductService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
        {
        }

        public Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddImageAsync(int id, BreadFile image)
        {
            throw new System.NotImplementedException();
        }
    }
}
