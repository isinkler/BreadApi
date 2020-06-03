using AutoMapper;

using Bread.DataTransfer;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services
{
    public class ProductService : BreadService, IProductService
    {
        public ProductService(IMapper mapper) : base(mapper)
        {
        }

        public Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> CreateAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
