using AutoMapper;
using System;
using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapCities();
            MapOrders();
            MapProducts();
            MapProductOrders();
            MapRestaurants();
            MapUsers();
        }

        private void MapCities()
        {
            CreateMap<BLL.City, DTO.City>();
            CreateMap<DTO.City, BLL.City>();
        }

        private void MapOrders()
        {
            CreateMap<BLL.Order, DTO.Order>();
            CreateMap<DTO.Order, BLL.Order>();
        }

        private void MapProducts()
        {
            CreateMap<BLL.Product, DTO.Product>();
            CreateMap<DTO.Product, BLL.Product>();
        }

        private void MapProductOrders()
        {
            CreateMap<BLL.ProductOrder, DTO.ProductOrder>();
            CreateMap<DTO.ProductOrder, BLL.ProductOrder>();
        }

        private void MapRestaurants()
        {
            CreateMap<BLL.Restaurant, DTO.Restaurant>();
            CreateMap<DTO.Restaurant, BLL.Restaurant>();
        }

        private void MapUsers()
        {
            CreateMap<BLL.User, DTO.User>()
                .ForMember(dtoUser => dtoUser.Password, options => options.Ignore());
            CreateMap<DTO.User, BLL.User>();
        }
    }
}
