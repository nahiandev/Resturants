using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Domains.DTOs;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Queries.GetResturants
{
    public class GetResturantsQueryHandler : IRequestHandler<GetResturantsQuery, IEnumerable<ResturantDTO>>
    {
        private readonly IResturantRepository _repository;

        public GetResturantsQueryHandler(IResturantRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ResturantDTO>> Handle(GetResturantsQuery request, CancellationToken cancellationToken)
        {
            var resturants = await _repository.GetResturantsAsync();

            if (resturants.Count is 0) return [];

            return [.. resturants.Select(DataMapper.Instance.Mapper)];
        }
    }
}
