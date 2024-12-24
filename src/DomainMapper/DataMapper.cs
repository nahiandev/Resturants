using Restaurants.Models.Domains;
using Restaurants.Models.DTOs;

namespace Restaurants.DomainMapper
{
    public sealed class DataMapper
    {
        private static readonly DataMapper _instance = new DataMapper();

        // Private constructor to prevent instantiation
        private DataMapper()
        {
        }

        // Public static property to access the singleton instance
        public static DataMapper Instance => _instance;

        public ResturantDTO Mapper(Resturant source)
        {
            return new()
            {
                Name = source.Name,
                Description = source.Description,
                Category = source.Category,
                HasDelivery = source.HasDelivery
            };
        }

        public Resturant Mapper(AddResturantDTO add_resturant_dto)
        {
            return new()
            {
                Name = add_resturant_dto.Name,
                Description = add_resturant_dto.Description,
                Category = add_resturant_dto.Category,
                HasDelivery = add_resturant_dto.HasDelivery,
                PhoneNumber = add_resturant_dto.PhoneNumber,
                Email = add_resturant_dto.Email
            };
        }
    }
}
