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
        }

        private void MapRestaurant()
        {
            CreateMap<BLL.Restaurant, DTO.Restaurant>();
            CreateMap<DTO.Restaurant, BLL.Restaurant>();
        }
    }
}
