using Restaurants.DataAccessor;
using Restaurants.DomainMapper;
using Restaurants.Domains.DTOs;
using Restaurants.Domains.Models;

namespace Restaurants.Seeders
{
    public class ResturantSeeder : IResturantSeeder
    {
        private readonly ResturantDbContext _context;

        public ResturantSeeder(ResturantDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.Resturants.Any())
                {
                    var resturants = GetResturants();
                    _context.Resturants.AddRange(resturants);
                    await _context.SaveChangesAsync();
                }
            }
        }


        private static IEnumerable<Resturant> GetResturants()
        {
            List<AddResturantDTO> dto_resturants =
            [
                new ()
                {
                    Name = "Italian Bistro",
                    Description = "A cozy place for authentic Italian cuisine.",
                    Category = "Italian",
                    HasDelivery = true,
                    PhoneNumber = "123-456-7890",
                    Email = "contact@italianbistro.com",
                },
                new ()
                {
                    Name = "Sushi World",
                    Description = "Fresh and delicious sushi.",
                    Category = "Japanese",
                    HasDelivery = false,
                    PhoneNumber = "987-654-3210",
                    Email = "info@sushiworld.com",
                },
                new ()
                {
                    Name = "Taco Fiesta",
                    Description = "Best tacos in town.",
                    Category = "Mexican",
                    HasDelivery = true,
                    PhoneNumber = "555-123-4567",
                    Email = "order@tacofiesta.com",
                },
                new ()
                {
                    Name = "Burger Haven",
                    Description = "Juicy burgers and crispy fries.",
                    Category = "American",
                    HasDelivery = false,
                    PhoneNumber = "444-555-6666",
                    Email = "support@burgerhaven.com",
                },
                new ()
                {
                    Name = "Curry House",
                    Description = "Authentic Indian curries.",
                    Category = "Indian",
                    HasDelivery = true,
                    PhoneNumber = "333-222-1111",
                    Email = "contact@curryhouse.com",
                },
                new ()
                {
                
                    Name = "Peking Duck House",
                    Description = "Delicious",
                    Category = "Chinese",
                    HasDelivery = true,
                    PhoneNumber = "666-777-8888",
                    Email = "donx@house.vox"
                },
                new ()
                {
                    Name = "Pasta Palace",
                    Description = "Delicious",
                    Category = "Italian",
                    HasDelivery = true,
                    PhoneNumber = "666-777-8888",
                    Email = "utral@hdg.co.in"
                },
                new ()
                {
                    Name = "Sushi Palace",
                    Description = "Delicious",
                    Category = "Japanese",
                    HasDelivery = true,
                    PhoneNumber = "666-777-8888",
                    Email = "serrc@olx.au"
                },
                new ()
                {
                    Name = "Taco Palace",
                    Description = "Delicious",
                    Category = "Mexican",
                    HasDelivery = true,
                    PhoneNumber = "666-777-8888",
                    Email = "ducky@paant.kz"
                },
                new ()
                {
                    Name = "Burger Palace",
                    Description = "Delicious",
                    Category = "American",
                    HasDelivery = true,
                    PhoneNumber = "666-777-8888",
                    Email = "grave@hylux.co.uk"
                }
            ];

            List<Resturant> converted_domain_resturants = [];

            //foreach (var resturant in dto_resturants)
            //{
            //    converted_domain_resturants.Add(DataMapper.Instance.Mapper(resturant));
            //}

            dto_resturants.ForEach(r => converted_domain_resturants.Add(DataMapper.Instance.Mapper(r)));

            return converted_domain_resturants;
        }
    }
}
