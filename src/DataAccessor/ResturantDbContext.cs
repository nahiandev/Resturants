using Microsoft.EntityFrameworkCore;
using Restaurants.Models.Domains;

namespace Restaurants.DataAccessor
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
            
        }

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Server=localhost;Database=Resturants;User Id=sa;Password=Password123;");
        //}

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Resturant>().OwnsOne(r => r.Address);

            model.Entity<Resturant>().HasMany(r => r.Dishes)
                .WithOne().HasForeignKey(d => d.ResturantId);
        }
    }
}
