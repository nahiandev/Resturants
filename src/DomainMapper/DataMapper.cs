using Restaurants.Actions.Commands.AddResturant;
using Restaurants.Actions.Queries.SharedDTO;
using Restaurants.Domains;

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
