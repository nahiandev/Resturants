using MediatR;
using Restaurants.Domains.DTOs;

namespace Restaurants.Actions.Commands.UpdateResturant
{
    public class UpdateResturantCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateResturantDTO Properties { get; set; }

        public UpdateResturantCommand(int id, UpdateResturantDTO properties)
        {
            Id = id;
            Properties = properties;
        }
    }
}
