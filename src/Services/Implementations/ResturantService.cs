﻿using Restaurants.Models.DTOs;
using Restaurants.Repository.Interfaces;
using Restaurants.Services.Interfaces;
using Restaurants.DomainMapper;

namespace Restaurants.Services.Implementations
{
    public class ResturantService : IResturantService
    {
        private readonly IResturantRepository _repository;

        public ResturantService(IResturantRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResturantDTO?> GetMappedResturantByIdAsync(int id)
        {
            var resturant = await _repository.GetResturantByIdAsync(id);

            if (resturant is null) return await Task.FromResult<ResturantDTO?>(null);

            return DataMapper.Instance.Mapper(resturant);
        }

        public async Task<List<ResturantDTO>> GetMappedResturantsAsync()
        {
            var resturants = await _repository.GetResturantsAsync();

            if (resturants.Count is 0) return [];

            return [..resturants.Select(DataMapper.Instance.Mapper)];
        }

        public async Task<int> AddMappedResturantAsync(AddResturantDTO add_resturant_dto)
        {
            var domain_resturant = DataMapper.Instance.Mapper(add_resturant_dto);

            await _repository.AddResturantAsync(domain_resturant);

            return domain_resturant.Id;
        }
    }
}