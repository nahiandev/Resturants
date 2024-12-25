using Restaurants.Models.DTOs;
using Restaurants.Repository.Interfaces;
using Restaurants.Services.Interfaces;
using Restaurants.DomainMapper;

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

        public async Task<List<ResturantDTO>> GetMappedResturantsAsync()
        {
            var resturants = await _repository.GetResturantsAsync();

            if (resturants.Count is 0) return [];

            return [..resturants.Select(DataMapper.Instance.Mapper)];
        }

        public async Task<(int id, ResturantDTO? resturant, bool modified)> AddMappedResturantAsync(AddResturantDTO add_resturant_dto)
        {
            var domain_resturant = DataMapper.Instance.Mapper(add_resturant_dto);

            try
            {
                var saved_resturant = await _repository.AddResturantAsync(domain_resturant!);

                return (saved_resturant.Id, DataMapper.Instance.Mapper(saved_resturant), false);
            }
            catch (Exception)
            {
                return (-1, await Task.FromResult<ResturantDTO?>(null), false);
            }
        }

        public async Task<(bool success, string? name)> DeleteMappedResturantAsync(int id)
        {
            var resource = await _repository.DeleteResturantAsync(id);

            //var resource_is_not_null = resource is not null;

            //if (resource_is_not_null) return (true, resource!.Name);

            //return (false, string.Empty);

            var resource_is_null = resource is null;

            if (resource_is_null) return (!resource_is_null, string.Empty);

            return (!resource_is_null, resource!.Name);
        }
    }
}
