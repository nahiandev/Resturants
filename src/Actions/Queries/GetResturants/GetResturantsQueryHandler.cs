using MediatR;
using Restaurants.Actions.Queries.SharedDTO;
using Restaurants.DomainMapper;
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
            try
            {
                var resturants = await _repository.GetResturantsAsync();

                if (resturants.Count is 0) return [];

                return [.. resturants.Select(DataMapper.Instance.Mapper)];
            }
            catch (Exception ex)
            {
                // Log exception
                throw;
            }
        }
    }
}
