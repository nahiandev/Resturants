using Restaurants.DataAccessor;
using Restaurants.Domains.Models;
using Resturants.Repository.Interfaces;

namespace Resturants.Repository.Implementations
{
    public class DishesRepository : IDishesRepository
    {
        private readonly ResturantDbContext _context;

        public DishesRepository(ResturantDbContext context)
        {
            _context = context;
        }
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
