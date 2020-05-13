using AutoMapper;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapRestaurant();
        }

        private void MapRestaurant()
        {
            CreateMap<DAL.Restaurant, BLL.Restaurant>();
            CreateMap<BLL.Restaurant, DAL.Restaurant>();
        }
    }
}
