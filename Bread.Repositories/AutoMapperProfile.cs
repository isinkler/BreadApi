using AutoMapper;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapCities();
            MapOrders();
            MapProducts();
            MapProductOrders();
            MapRestaurant();
            MapUser();
        }

        private void MapCities()
        {
            CreateMap<DAL.City, BLL.City>();
            CreateMap<BLL.City, DAL.City>();
        }

        private void MapOrders()
        {
            CreateMap<DAL.Order, BLL.Order>();
            CreateMap<BLL.Order, DAL.Order>();
        }

        private void MapProducts()
        {
            CreateMap<DAL.Product, BLL.Product>();
            CreateMap<BLL.Product, DAL.Product>();
        }

        private void MapProductOrders()
        {
            CreateMap<DAL.ProductOrder, BLL.ProductOrder>();
            CreateMap<BLL.ProductOrder, DAL.ProductOrder>();
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
