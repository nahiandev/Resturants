using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.DataSeeder.Interfaces;
using Restaurants.Models.Domains;

namespace Restaurants.DataSeeder.Implementations
{
    public class ResturantSeeder /*: IResturantSeeder*/
    {
        private readonly ResturantDbContext _context;

        public ResturantSeeder(ResturantDbContext context)
        {
            _context = context;
        }

        //public async Task SeedAsync()
        //{
        //    var canConnect = await _context.Database.CanConnectAsync();
        //    if (canConnect)
        //    {
        //        var resturantDataExists = await _context.Resturants.AnyAsync();
        //        if (!resturantDataExists)
        //        {
        //            var resturants = GetResturants();
        //            await _context.Resturants.AddRangeAsync(resturants);
        //            await _context.SaveChangesAsync();


        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateException ex)
        //            { // Log the inner exception
        //                Console.WriteLine(ex.InnerException?.Message);
        //                throw;
        //            }
        //        }
        //    }
        //}

        
    }
}
