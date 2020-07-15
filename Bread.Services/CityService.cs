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
    public class CityService : BreadService, ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(IMapper mapper, ICityRepository cityRepository)
            : base(mapper)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<City> CreateAsync(DTO.City city)
        {
            var bllCity = Mapper.Map<BLL.City>(city);

            bllCity = await cityRepository.CreateAsync(bllCity);

            city = Mapper.Map<DTO.City>(bllCity);

            return city;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<City>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<City> GetAsync(int id)
        {
            BLL.City bllCity = await cityRepository.GetAsync(id);

            var result = Mapper.Map<DTO.City>(bllCity);

            return result;
        }

        public Task<City> UpdateAsync(City dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
