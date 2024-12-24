using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.Models.Domains;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Repository.Implementations
{
    public class ResturantRepository : IResturantRepository
    {
        private readonly ResturantDbContext _context;

        public ResturantRepository(ResturantDbContext context)
        {
            _context = context;
        }
        public async Task<Resturant?> GetResturantByIdAsync(int id)
        {
            var resturant = await _context.Resturants.FirstOrDefaultAsync(r => r.Id == id);
            if (resturant is null)
            {
                return await Task.FromResult<Resturant?>(null);
            }

            return resturant;
        }

        public async Task<List<Resturant>> GetResturantsAsync()
        {
            var resturants = await _context.Resturants.ToListAsync();
            if (resturants.Count == 0)
            {
                return [];
            }

            return resturants;
        }
    }
}
