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
        public async Task<Dish> AddDishAsync(Dish add_dish, CancellationToken cancellation_token)
        {
            _context.Dishes.Add(add_dish);

            await _context.SaveChangesAsync();

            return add_dish;
        }

        public Task<bool> DeleteDishAsync(int id, CancellationToken cancellation_token)
        {
            throw new NotImplementedException();
        }

        public Task<Dish?> GetDishByIdAsync(int id, CancellationToken cancellation_token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dish>?> GetDishesAsync(CancellationToken cancellation_token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDishAsync(int id, Dish update_dish, CancellationToken cancellation_token)
        {
            throw new NotImplementedException();
        }
    }
}
