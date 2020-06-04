using AutoMapper;

using Bread.Data;
using Bread.Domain.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class ProductRepository : GenericBreadRepository<DAL.Product, BLL.Product>, IProductRepository
    {
        public ProductRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        
        public async Task<IEnumerable<Product>> GetAllByRestaurantAsync(int restaurantId)
        {
            List<DAL.Product> dalProducts = 
                await Context.Products.Where(product => product.RestaurantId == restaurantId).ToListAsync();

            var result = Mapper.Map<IEnumerable<BLL.Product>>(dalProducts);

            return result;
        }
                      
    }
}
