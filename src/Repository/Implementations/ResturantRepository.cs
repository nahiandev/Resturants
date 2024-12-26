using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.Domains;
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

        public async Task<Resturant> AddResturantAsync(Resturant add_resturant)
        {
            await _context.Resturants.AddAsync(add_resturant);

            await _context.SaveChangesAsync();

            return add_resturant;
        }

        public async Task<bool> DeleteResturantAsync(int id)
        {
            var resturant = _context.Resturants.FirstOrDefault(r => r.Id == id);
            
            if (resturant is null) return false;

            _context.Resturants.Remove(resturant);

            await _context.SaveChangesAsync();

            return true;
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

        public async Task<bool> UpdateResturantAsync(int id, Resturant update_resturant)
        {
            var existing_resturant = await _context.Resturants.FirstOrDefaultAsync(r => r.Id == id);

            if (existing_resturant is null) return false;

            bool are_same = update_resturant.Equals(existing_resturant);

            if (are_same) return false;


            existing_resturant.Name = update_resturant.Name;

            existing_resturant.Description = update_resturant.Description;

            existing_resturant.Category = update_resturant.Category;

            existing_resturant.HasDelivery = update_resturant.HasDelivery;

            existing_resturant.PhoneNumber = update_resturant.PhoneNumber;

            existing_resturant.Email = update_resturant.Email;



            _context.Resturants.Update(existing_resturant);

            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
