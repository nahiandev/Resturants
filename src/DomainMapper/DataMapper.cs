using Restaurants.Actions.Coomands.AddResturant;
using Restaurants.Models.Domains;
using Restaurants.Models.DTOs;

namespace Restaurants.DomainMapper
{
    public sealed class DataMapper
    {
        private static readonly DataMapper _instance = new();

        private DataMapper()
        {
        }

        public static DataMapper Instance => _instance;

        public ResturantDTO Mapper(Resturant source) => new()
        {
            Name = source.Name,
            Description = source.Description,
            Category = source.Category,
            HasDelivery = source.HasDelivery,
            PhoneNumber = source.PhoneNumber,
            Email = source.Email
        };
        

        public Resturant Mapper(AddResturantDTO add_resturant_dto) => new()
        {
            Name = add_resturant_dto.Name,
            Description = add_resturant_dto.Description,
            Category = add_resturant_dto.Category,
            PhoneNumber = add_resturant_dto.PhoneNumber,
            Email = add_resturant_dto.Email
        };
        
        public Resturant Mapper(AddResturantCommand add_resturant_command) => new()
        {
            Name = add_resturant_command.Name,
            Description = add_resturant_command.Description,
            Category = add_resturant_command.Category,
            PhoneNumber = add_resturant_command.PhoneNumber,
            Email = add_resturant_command.Email
        };
    }
}
