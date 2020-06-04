using AutoMapper;

using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services
{
    public abstract class GenericBreadService<TDomain, TDto> : BreadService, IGenericBreadService<TDto>        
        where TDomain : class
    {
        private readonly IGenericBreadRepository<TDomain> repository;

        public GenericBreadService(IGenericBreadRepository<TDomain> repository, IMapper mapper) : base(mapper)
        {
            this.repository = repository;
        }

        public Task<TDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var domain = Mapper.Map<TDomain>(dto);

            domain = await repository.CreateAsync(domain);

            dto = Mapper.Map<TDto>(domain);

            return dto;
        }

        public Task<TDto> UpdateAsync(TDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
