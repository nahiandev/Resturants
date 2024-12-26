using MediatR;
using Restaurants.Actions.DTOs;

namespace Restaurants.Actions.Queries.GetResturants
{
    public class GetResturantsQuery : IRequest<IEnumerable<ResturantDTO>>
    {
    }
}
