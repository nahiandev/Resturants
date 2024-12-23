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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Resturant>().HasData(GetResturants());
            

            // Seed data for Dishes
            //modelBuilder.Entity<Dish>().HasData(
            //    new Dish
            //    {
            //        Id = 1,
            //        Name = "Big Mac",
            //        Description = "Tasty",
            //        Price = 5.99m,
                
            //    },
            //    new Dish
            //    {
            //        Id = 2,
            //        Name = "McNuggets",
            //        Description = "Tasty",
            //        Price = 4.99m,
                   
            //    }
            //);
        }


        private IEnumerable<Resturant> GetResturants()
        {
            List<Resturant> resturants = new List<Resturant>
            {
                new Resturant
                {
                    Id = 1,
                    Name = "Italian Bistro",
                    Description = "A cozy place for authentic Italian cuisine.",
                    Category = "Italian",
                    HasDelivery = true,
                    PhoneNumber = "123-456-7890",
                    Email = "contact@italianbistro.com",

                },
                new Resturant
                {
                    Id = 2,
                    Name = "Sushi World",
                    Description = "Fresh and delicious sushi.",
                    Category = "Japanese",
                    HasDelivery = false,
                    PhoneNumber = "987-654-3210",
                    Email = "info@sushiworld.com",

                },
                new Resturant
                {
                    Id = 3,
                    Name = "Taco Fiesta",
                    Description = "Best tacos in town.",
                    Category = "Mexican",
                    HasDelivery = true,
                    PhoneNumber = "555-123-4567",
                    Email = "order@tacofiesta.com",

                },
                new Resturant
                {
                    Id = 4,
                    Name = "Burger Haven",
                    Description = "Juicy burgers and crispy fries.",
                    Category = "American",
                    HasDelivery = false,
                    PhoneNumber = "444-555-6666",
                    Email = "support@burgerhaven.com",

                },
                new Resturant
                {
                    Id = 5,
                    Name = "Curry House",
                    Description = "Authentic Indian curries.",
                    Category = "Indian",
                    HasDelivery = true,
                    PhoneNumber = "333-222-1111",
                    Email = "contact@curryhouse.com",

                }
            };

            return resturants;
        }
    }
}
