using Restaurants.Models.Domains;
using Restaurants.Models.DTOs;
using Restaurants.Repository.Interfaces;
using Restaurants.Services.Interfaces;

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

            return Mapper(resturant);
        }

        public async Task<List<ResturantDTO>> GetMappedResturantsAsync()
        {
            var resturants = await _repository.GetResturantsAsync();

            if (resturants.Count is 0) return [];

            return [..resturants.Select(Mapper)];
        }

        private static ResturantDTO Mapper(Resturant source)
        {
            return new()
            {
                Name = source.Name,
                Description = source.Description,
                Category = source.Category,
                HasDelivery = source.HasDelivery
            };
        }
    }
}
