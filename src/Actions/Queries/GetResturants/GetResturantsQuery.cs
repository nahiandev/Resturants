using MediatR;
using Restaurants.Actions.Queries.SharedDTO;

namespace Restaurants.Actions.Queries.GetResturants
{
    public class GetResturantsQuery : IRequest<IEnumerable<ResturantDTO>>
    {
    }
}
