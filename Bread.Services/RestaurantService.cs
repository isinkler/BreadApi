﻿using AutoMapper;

using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class RestaurantService : BreadService, IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IMapper mapper, IRestaurantRepository restaurantRepository)
            :base(mapper)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<DTO.Restaurant>> GetAllAsync()
        {
            IEnumerable<BLL.Restaurant> restaurants = await restaurantRepository.GetAllAsync();

            var result = Mapper.Map<IEnumerable<DTO.Restaurant>>(restaurants);

            return result;
        }
    }
}
