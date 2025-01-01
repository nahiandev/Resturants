using Restaurants.Domains.Models;

namespace Resturants.Repository.Interfaces
{
    public interface IDishesRepository
    {
        Task<List<Dish>> GetDishesAsync(CancellationToken cancellation_token);
        Task<Dish?> GetDishByIdAsync(int id, CancellationToken cancellation_token);
        Task<Dish> AddDishAsync(Dish add_dish, CancellationToken cancellation_token);
        Task<bool> DeleteDishAsync(int id, CancellationToken cancellation_token);
        Task<bool> UpdateDishAsync(int id, Dish update_dish, CancellationToken cancellation_token);
    }
}
