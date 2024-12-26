using MediatR;
using Restaurants.Domains.DTOs;

namespace Restaurants.Actions.Queries.GetResturants
{
    public class GetResturantsQuery : IRequest<IEnumerable<ResturantDTO>>
    {
    }
}
