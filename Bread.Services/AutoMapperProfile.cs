using AutoMapper;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapRestaurant();
            MapUser();
        }

        private void MapRestaurant()
        {
            CreateMap<BLL.Restaurant, DTO.Restaurant>();
            CreateMap<DTO.Restaurant, BLL.Restaurant>();
        }

        private void MapUser()
        {
            CreateMap<BLL.User, DTO.User>()
                .ForMember(dtoUser => dtoUser.Password, options => options.Ignore());
            CreateMap<DTO.User, BLL.User>();
        }
    }
}
