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
        public async Task<int> AddDishAsync(Dish add_dish, CancellationToken cancellation_token)
        {
            _context.Dishes.Add(add_dish);

            await _context.SaveChangesAsync();

            return add_dish.Id;
        }
    }
}
