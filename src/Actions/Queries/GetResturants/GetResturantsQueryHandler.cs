using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Domains.DTOs;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Queries.GetResturants
{
    public class GetResturantsQueryHandler : IRequestHandler<GetResturantsQuery, IEnumerable<ResturantDTO>>
    {
        private readonly IResturantRepository _repository;

        private readonly ILogger<GetResturantsQueryHandler> _logger;

        public GetResturantsQueryHandler(IResturantRepository repository, ILogger<GetResturantsQueryHandler> logger)
        {
            _repository = repository;

            _logger = logger;
        }
        public async Task<IEnumerable<ResturantDTO>> Handle(GetResturantsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all Resturants with {@GetResturants}", request);
            try
            {
                var resturants = await _repository.GetResturantsAsync();

                if (resturants.Count is 0) return [];

                return [.. resturants.Select(DataMapper.Instance.Mapper)];
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error getting all Resturants with {@GetResturants}", ex.Message);

                throw;
            }
        }
    }
}
