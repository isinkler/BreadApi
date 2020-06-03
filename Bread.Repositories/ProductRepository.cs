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
    public class ProductRepository : BreadRepository, IProductRepository
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

        public async Task<Product> GetAsync(int id)
        {
            DAL.Product dalProduct =
                await Context.Products.SingleOrDefaultAsync(entity => entity.Id == id);

            var result = Mapper.Map<BLL.Product>(dalProduct);

            return result;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var dalProduct = Mapper.Map<DAL.Product>(product);

            await Context.Products.AddAsync(dalProduct);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<BLL.Product>(dalProduct);

            return result;
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
