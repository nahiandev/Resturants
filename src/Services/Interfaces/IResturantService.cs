using Restaurants.Actions.Queries.SharedDTO;

namespace Restaurants.Services.Interfaces
{
    public interface IResturantService
    {
       
        
        Task<(bool success, string? name)> DeleteMappedResturantAsync(int id);
    }
}
