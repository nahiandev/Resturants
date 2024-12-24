using Restaurants.Models.DTOs;

namespace Restaurants.Services.Interfaces
{
    public interface IResturantService
    {
        Task<List<ResturantDTO>> GetMappedResturantsAsync();
        Task<ResturantDTO?> GetMappedResturantByIdAsync(int id);
        Task<int> AddMappedResturantAsync(AddResturantDTO add_resturant_dto);
    }
}
