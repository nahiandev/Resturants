using MediatR;
using Restaurants.Domains.DTOs;

namespace Restaurants.Actions.Commands.AddResturant
{
    public class AddResturantCommand : IRequest<int>
    {
        public AddResturantDTO Properties { get; set; }

        public AddResturantCommand(AddResturantDTO properties)
        {
            Properties = properties;
        }
    }
}
