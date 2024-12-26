using MediatR;
using Restaurants.Actions.DTOs;

namespace Restaurants.Actions.Queries.GetResturantById
{
    public class GetResturantByIdQuery : IRequest<ResturantDTO?>
    {
        public int Id { get; }
        public GetResturantByIdQuery(int id)
        {
            Id = id;
        }
    }
}
