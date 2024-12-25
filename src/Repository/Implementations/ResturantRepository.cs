using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.Models.Domains;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Repository.Implementations
{
    public class ResturantRepository : IResturantRepository
    {
        // Purely responsible for data access

        private readonly ResturantDbContext _context;

        public ResturantRepository(ResturantDbContext context)
        {
            _context = context;
        }

        public async Task<(bool exists, Resturant? resturant)> AddResturantAsync(Resturant add_resturant)
        {
            var existing_resturant = await _context.Resturants.FirstOrDefaultAsync(r => r.Email == add_resturant.Email);

            var exists = existing_resturant is not null;

            if (exists) return (exists, existing_resturant);
            
            await _context.Resturants.AddAsync(add_resturant);

            await _context.SaveChangesAsync();

            return (exists, add_resturant);
        }

        public async Task<Resturant?> DeleteResturantAsync(int id)
        {
            var resturant = _context.Resturants.FirstOrDefault(r => r.Id == id);
            
            if (resturant is null) return await Task.FromResult<Resturant?>(null);

            _context.Resturants.Remove(resturant);

            await _context.SaveChangesAsync();

            return resturant;
        }

        public async Task<Resturant?> GetResturantByIdAsync(int id)
        {
            var resturant = await _context.Resturants.FirstOrDefaultAsync(r => r.Id == id);

            if (resturant is null) return await Task.FromResult<Resturant?>(null);
            
            return resturant;
        }

        public async Task<List<Resturant>> GetResturantsAsync()
        {
            var resturants = await _context.Resturants.ToListAsync();

            if (resturants.Count == 0) return [];
            
            return resturants;
        }
    }
}
