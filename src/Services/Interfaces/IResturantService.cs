using Restaurants.Models.DTOs;

namespace Restaurants.Services.Interfaces
{
    public interface IResturantService
    {
        Task<List<ResturantDTO>> GetMappedResturantsAsync();
        Task<ResturantDTO?> GetMappedResturantByIdAsync(int id);
        Task<(int id, ResturantDTO? resturant)> AddMappedResturantAsync(AddResturantDTO add_resturant_dto);
        Task<(bool success, string? name)> DeleteMappedResturantAsync(int id);
    }
}
