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
            MapOrders();
            MapProducts();
            MapProductOrders();
            MapRestaurant();
            MapUser();
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
