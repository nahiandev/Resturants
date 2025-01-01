using Restaurants.Domains.Models;
using Resturants.Repository.Interfaces;

namespace Resturants.Repository.Implementations
{
    public class DishesRepository : IDishesRepository
    {
        public Task<Dish> AddDishAsync(Dish add_dish)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDishAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Dish?> GetDishByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dish>> GetDishesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDishAsync(int id, Dish update_dish)
        {
            throw new NotImplementedException();
        }
    }
}
