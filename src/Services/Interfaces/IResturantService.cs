using Restaurants.Actions.Queries.SharedDTO;

namespace Restaurants.Services.Interfaces
{
    public interface IResturantService
    {
       
        Task<ResturantDTO?> GetMappedResturantByIdAsync(int id);
        Task<(bool success, string? name)> DeleteMappedResturantAsync(int id);
    }
}
