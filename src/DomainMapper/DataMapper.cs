using Restaurants.Actions.Commands.AddResturant;
using Restaurants.Actions.Commands.UpdateResturant;
using Restaurants.Domains.DTOs;
using Restaurants.Domains.Models;
using Resturants.Actions.Commands.AddDish;
using Resturants.Domains.DTOs;

namespace Restaurants.DomainMapper
{
    public sealed class DataMapper
    {
        private static readonly DataMapper _instance = new();

        private DataMapper()
        {
        }

        public static DataMapper Instance => _instance;

        public ResturantDTO Map(Resturant source) => new()
        {
            Name = source.Name,
            Description = source.Description,
            Category = source.Category,
            HasDelivery = source.HasDelivery,
            PhoneNumber = source.PhoneNumber,
            Email = source.Email
        };
        
        public Resturant Map(AddResturantCommand add_resturant_command) => new()
        {
            Name = add_resturant_command.Name,
            Description = add_resturant_command.Description,
            Category = add_resturant_command.Category,
            PhoneNumber = add_resturant_command.PhoneNumber,
            Email = add_resturant_command.Email
        };
        
        public Resturant Map(AddResturantDTO add_resturant_dto) => new()
        {
            Name = add_resturant_dto.Name,
            Description = add_resturant_dto.Description,
            Category = add_resturant_dto.Category,
            PhoneNumber = add_resturant_dto.PhoneNumber,
            Email = add_resturant_dto.Email
        };

        public Resturant Map(UpdateResturantCommand update_resturant) => new()
        {
            Name = update_resturant.Name,
            Description = update_resturant.Description,
            Category = update_resturant.Category,
            PhoneNumber = update_resturant.PhoneNumber,
            Email = update_resturant.Email
        };

        public Dish Map(AddDishDTO command) => new()
        {
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            KiloCalories = command.KiloCalories
        };
    }
}
