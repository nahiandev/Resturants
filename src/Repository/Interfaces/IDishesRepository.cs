using Restaurants.Domains.Models;

namespace Resturants.Repository.Interfaces
{
    public interface IDishesRepository
    {
        Task<List<Dish>> GetDishesAsync();
        Task<Dish?> GetDishByIdAsync(int id);
        Task<Dish> AddDishAsync(Dish add_dish);
        Task<bool> DeleteDishAsync(int id);
        Task<bool> UpdateDishAsync(int id, Dish update_dish);
    }
}
