using Restaurants.Domains.Models;

namespace Restaurants.Repository.Interfaces
{
    public interface IResturantRepository
    {
        Task<List<Resturant>> GetResturantsAsync();
        Task<Resturant?> GetResturantByIdAsync(int id);
        Task<Resturant> AddResturantAsync(Resturant add_resturant);
        Task<bool> DeleteResturantAsync(int id);
        Task<bool> UpdateResturantAsync(int id, Resturant update_resturant);
    }
}