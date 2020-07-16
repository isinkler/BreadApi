using AutoMapper;

using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class CityService : GenericBreadService<BLL.City, DTO.City>, ICityService
    {        
        public CityService(ICityRepository cityRepository, IMapper mapper)
            : base(cityRepository, mapper)
        {            
        }        
    }
}
