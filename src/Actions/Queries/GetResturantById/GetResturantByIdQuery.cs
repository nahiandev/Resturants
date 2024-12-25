using MediatR;
using Restaurants.Actions.Queries.SharedDTO;

namespace Restaurants.Actions.Queries.GetResturantById
{
    public class GetResturantByIdQuery : IRequest<ResturantDTO?>
    {
        public int Id { get; set; }
    }
}
