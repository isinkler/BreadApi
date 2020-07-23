using AutoMapper;

using Bread.DataTransfer;
using Bread.Domain.Models;
using Bread.Exceptions;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services
{
    public abstract class GenericBreadService<TDomainModel, TDataTransfer> : BreadService, IGenericBreadService<TDataTransfer>        
        where TDomainModel : BreadDomainModel
        where TDataTransfer : BreadDataTransfer
    {
        private readonly IGenericBreadRepository<TDomainModel> repository;

        public GenericBreadService(IGenericBreadRepository<TDomainModel> repository, IMapper mapper) : base(mapper)
        {
            this.repository = repository;
        }

        public virtual async Task<TDataTransfer> GetAsync(int id)
        {
            TDomainModel domainModel = await repository.GetAsync(id);

            var result = Mapper.Map<TDataTransfer>(domainModel);

            return result;
        }

        public virtual async Task<IEnumerable<TDataTransfer>> GetAllAsync()
        {            
            IEnumerable<TDomainModel> domainModels = await repository.GetAllAsync();            
            
            var result = Mapper.Map<IEnumerable<TDataTransfer>>(domainModels);

            return result;
        }

        public virtual async Task<TDataTransfer> CreateAsync(TDataTransfer dataTransfer)
        {
            var domainModel = Mapper.Map<TDomainModel>(dataTransfer);

            domainModel = await repository.CreateAsync(domainModel);

            dataTransfer = Mapper.Map<TDataTransfer>(domainModel);

            return dataTransfer;
        }

        public virtual Task<TDataTransfer> UpdateAsync(TDataTransfer dto)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
