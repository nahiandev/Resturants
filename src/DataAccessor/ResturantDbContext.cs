using Microsoft.EntityFrameworkCore;
using Restaurants.Domains.Models;

namespace Restaurants.DataAccessor
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }

        public DbSet<Resturant> Resturants { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore());
        }
    }
}
