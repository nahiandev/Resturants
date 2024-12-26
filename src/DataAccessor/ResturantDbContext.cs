using Microsoft.EntityFrameworkCore;
using Restaurants.Domains.Models;

namespace Restaurants.DataAccessor
{
    public class ResturantDbContext : DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }

        public DbSet<Resturant> Resturants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore());
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Resturant>().HasData(GetResturants());
        //}
        //private static IEnumerable<Resturant> GetResturants()
        //{
        //    List<Resturant> resturants =
        //    [
        //        new ()
        //        {
        //            Id = 1,
        //            Name = "Italian Bistro",
        //            Description = "A cozy place for authentic Italian cuisine.",
        //            Category = "Italian",
        //            HasDelivery = true,
        //            PhoneNumber = "123-456-7890",
        //            Email = "contact@italianbistro.com",
        //        },
        //        new ()
        //        {
        //            Id = 2,
        //            Name = "Sushi World",
        //            Description = "Fresh and delicious sushi.",
        //            Category = "Japanese",
        //            HasDelivery = false,
        //            PhoneNumber = "987-654-3210",
        //            Email = "info@sushiworld.com",
        //        },
        //        new ()
        //        {
        //            Id = 3,
        //            Name = "Taco Fiesta",
        //            Description = "Best tacos in town.",
        //            Category = "Mexican",
        //            HasDelivery = true,
        //            PhoneNumber = "555-123-4567",
        //            Email = "order@tacofiesta.com",
        //        },
        //        new ()
        //        {
        //           Id = 4,
        //            Name = "Burger Haven",
        //            Description = "Juicy burgers and crispy fries.",
        //            Category = "American",
        //            HasDelivery = false,
        //            PhoneNumber = "444-555-6666",
        //            Email = "support@burgerhaven.com",
        //        },
        //        new ()
        //        {
        //            Id = 5,
        //            Name = "Curry House",
        //            Description = "Authentic Indian curries.",
        //            Category = "Indian",
        //            HasDelivery = true,
        //            PhoneNumber = "333-222-1111",
        //            Email = "contact@curryhouse.com",
        //        },
        //        new ()
        //        {
        //            Id = 6,
        //            Name = "Peking Duck House",
        //            Description = "Delicious",
        //            Category = "Chinese",
        //            HasDelivery = true,
        //            PhoneNumber = "666-777-8888",
        //            Email = "donx@house.vox"
        //        },
        //        new ()
        //        {
        //            Id = 7,
        //            Name = "Pasta Palace",
        //            Description = "Delicious",
        //            Category = "Italian",
        //            HasDelivery = true,
        //            PhoneNumber = "666-777-8888",
        //            Email = "utral@hdg.co.in"
        //        },
        //        new ()
        //        {
        //            Id = 8,
        //            Name = "Sushi Palace",
        //            Description = "Delicious",
        //            Category = "Japanese",
        //            HasDelivery = true,
        //            PhoneNumber = "666-777-8888",
        //            Email = "serrc@olx.au"
        //        },
        //        new ()
        //        {
        //            Id = 9,
        //            Name = "Taco Palace",
        //            Description = "Delicious",
        //            Category = "Mexican",
        //            HasDelivery = true,
        //            PhoneNumber = "666-777-8888",
        //            Email = "ducky@paant.kz"
        //        },
        //        new ()
        //        {
        //            Id = 10,
        //            Name = "Burger Palace",
        //            Description = "Delicious",
        //            Category = "American",
        //            HasDelivery = true,
        //            PhoneNumber = "666-777-8888",
        //            Email = "grave@hylux.co.uk"
        //        }
        //    ];

        //    return resturants;
        //}
    }
}
