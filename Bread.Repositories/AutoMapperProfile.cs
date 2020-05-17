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
            MapUser();
        }

        private void MapRestaurant()
        {
            CreateMap<DAL.Restaurant, BLL.Restaurant>();
            CreateMap<BLL.Restaurant, DAL.Restaurant>();
        }

        private void MapUser()
        {
            CreateMap<DAL.User, BLL.User>();
            CreateMap<BLL.User, DAL.User>();
        }
    }
}
