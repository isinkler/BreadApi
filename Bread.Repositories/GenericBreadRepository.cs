using AutoMapper;

using Bread.Data;
using Bread.Data.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Repositories
{
    public abstract class GenericBreadRepository<TData, TDomain> : BreadRepository, IGenericBreadRepository<TDomain>
        where TData : BreadDataModel
        where TDomain : class
    {
        public GenericBreadRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<TDomain> GetAsync(int id)
        {
            TData entity =
                await Context.Set<TData>().SingleOrDefaultAsync(contextEntity => contextEntity.Id == id);

            var result = Mapper.Map<TDomain>(entity);

            return result;
        }

        public Task<IEnumerable<TDomain>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<TDomain> CreateAsync(TDomain domainModel)
        {
            var entity = Mapper.Map<TData>(domainModel);

            await Context.Set<TData>().AddAsync(entity);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<TDomain>(entity);

            return result;
        }

        public Task<TDomain> UpdateAsync(TDomain entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
