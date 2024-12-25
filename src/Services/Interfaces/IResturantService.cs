using Restaurants.Models.DTOs;

namespace Restaurants.Services.Interfaces
{
    public interface IResturantService
    {
        Task<List<ResturantDTO>> GetMappedResturantsAsync();
        Task<ResturantDTO?> GetMappedResturantByIdAsync(int id);
        Task<(bool success, string? name)> DeleteMappedResturantAsync(int id);
    }
}
