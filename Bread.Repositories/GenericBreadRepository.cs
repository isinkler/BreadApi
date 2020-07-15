using AutoMapper;

using Bread.Common.Extensions;
using Bread.Data;
using Bread.Data.Models;
using Bread.Domain.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bread.Repositories
{
    public abstract class GenericBreadRepository<TDataModel, TDomainModel> : BreadRepository, IGenericBreadRepository<TDomainModel>
        where TDataModel : BreadDataModel
        where TDomainModel : BreadDomainModel
    {
        public GenericBreadRepository(BreadDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public virtual async Task<TDomainModel> GetAsync(int id)
        {
            TDataModel entity =
                await Context.Set<TDataModel>().SingleOrDefaultAsync(contextEntity => contextEntity.Id == id);

            var result = Mapper.Map<TDomainModel>(entity);

            return result;
        }

        public virtual async Task<IEnumerable<TDomainModel>> GetAllAsync()
        {
            IQueryable<TDataModel> entitiesQuery = Context.Set<TDataModel>();

            List<TDataModel> entities = await entitiesQuery.ToListAsync();

            var result = Mapper.Map<IEnumerable<TDomainModel>>(entities);

            return result;
        }

        public virtual async Task<TDomainModel> CreateAsync(TDomainModel domainModel)
        {
            var entity = Mapper.Map<TDataModel>(domainModel);

            await Context.Set<TDataModel>().AddAsync(entity);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<TDomainModel>(entity);

            return result;
        }

        public virtual async Task<TDomainModel> UpdateAsync(TDomainModel domainModel)
        {
            TDataModel entity =
                await Context.Set<TDataModel>().SingleOrDefaultAsync(entity => entity.Id == domainModel.Id);

            entity.ThrowIfNull(nameof(entity));

            Mapper.Map(domainModel, entity);

            Context.Update(entity);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<TDomainModel>(entity);

            return result;
        }

        public virtual  Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
