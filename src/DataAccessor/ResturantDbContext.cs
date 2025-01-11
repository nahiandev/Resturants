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
        internal DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options_builder)
        {
            base.OnConfiguring(options_builder);

            options_builder.ConfigureWarnings(warnings => warnings.Ignore());
        }

        protected override void OnModelCreating(ModelBuilder model_builder)
        {
            base.OnModelCreating(model_builder);

            model_builder.Entity<Resturant>().OwnsOne(r => r.Address);

            model_builder.Entity<Resturant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
