using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.Models.Domains;

namespace Restaurants.DataSeeder
{
    public class ResturantSeeder
    {
        private readonly ResturantDbContext _context;

        public ResturantSeeder(ResturantDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            var canConnect = await _context.Database.CanConnectAsync();
            if (canConnect)
            {
                var resturantDataExists = await _context.Resturants.AnyAsync();
                if (!resturantDataExists)
                {
                    var resturants = GetResturants();
                    await _context.Resturants.AddRangeAsync(resturants);
                    await _context.SaveChangesAsync();
                }
            }
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
                    Address = new Address
                    {
                        City = "New York",
                        Street = "123 Main St",
                        ZipCode = "10001"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Id = 1, Name = "Spaghetti Carbonara", Description = "Classic Italian pasta dish.", Price = 12.99M, ResturantId = 1 },
                        new Dish { Id = 2, Name = "Margherita Pizza", Description = "Traditional pizza with fresh tomatoes and basil.", Price = 10.99M, ResturantId = 1 }
                    }
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
                    Address = new Address
                    {
                        City = "San Francisco",
                        Street = "456 Market St",
                        ZipCode = "94105"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Id = 3, Name = "California Roll", Description = "Crab and avocado roll.", Price = 8.99M, ResturantId = 2 },
                        new Dish { Id = 4, Name = "Spicy Tuna Roll", Description = "Tuna with a spicy kick.", Price = 9.99M, ResturantId = 2 }
                    }
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
                    Address = new Address
                    {
                        City = "Los Angeles",
                        Street = "789 Sunset Blvd",
                        ZipCode = "90028"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Id = 5, Name = "Carne Asada Taco", Description = "Grilled steak taco.", Price = 3.99M, ResturantId = 3 },
                        new Dish { Id = 6, Name = "Chicken Taco", Description = "Grilled chicken taco.", Price = 3.49M, ResturantId = 3 }
                    }
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
                    Address = new Address
                    {
                        City = "Chicago",
                        Street = "101 Lake Shore Dr",
                        ZipCode = "60601"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Id = 7, Name = "Cheeseburger", Description = "Classic cheeseburger with all the fixings.", Price = 7.99M, ResturantId = 4 },
                        new Dish { Id = 8, Name = "Bacon Burger", Description = "Burger topped with crispy bacon.", Price = 8.99M, ResturantId = 4 }
                    }
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
                    Address = new Address
                    {
                        City = "Houston",
                        Street = "202 Main St",
                        ZipCode = "77002"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Id = 9, Name = "Chicken Tikka Masala", Description = "Grilled chicken in a creamy tomato sauce.", Price = 11.99M, ResturantId = 5 },
                        new Dish { Id = 10, Name = "Lamb Vindaloo", Description = "Spicy lamb curry.", Price = 12.99M, ResturantId = 5 }
                    }
                }
            };

            return resturants;
        }
    }
}
