﻿using Restaurants.Repository.Interfaces;
using Restaurants.Services.Interfaces;
using Restaurants.DomainMapper;
using Restaurants.Actions.Queries.SharedDTO;

namespace Restaurants.Services.Implementations
{
    public class ResturantService : IResturantService
    {
        // Purely responsible for business logic
        // Mapping errors are handled here

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

        public async Task<(bool success, string? name)> DeleteMappedResturantAsync(int id)
        {
            var resource = await _repository.DeleteResturantAsync(id);

            var resource_is_null = resource is null;

            if (resource_is_null) return (!resource_is_null, string.Empty);

            return (!resource_is_null, resource!.Name);
        }
    }
}
