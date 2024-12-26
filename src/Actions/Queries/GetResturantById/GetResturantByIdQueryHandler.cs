using MediatR;
using Restaurants.Actions.DTOs;
using Restaurants.DomainMapper;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Queries.GetResturantById
{
    public class GetResturantByIdQueryHandler : IRequestHandler<GetResturantByIdQuery, ResturantDTO?>
    {
        private readonly IResturantRepository _repository;

        private readonly ILogger<GetResturantByIdQueryHandler> _logger;

        public GetResturantByIdQueryHandler(IResturantRepository repository, ILogger<GetResturantByIdQueryHandler> logger)
        {
            _repository = repository;

            _logger = logger;
        }
        public async Task<ResturantDTO?> Handle(GetResturantByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting Resturant with {@GetResturantById}", request);

            try
            {
                var resturant = await _repository.GetResturantByIdAsync(request.Id);

                if (resturant is null) return await Task.FromResult<ResturantDTO?>(null);

                return DataMapper.Instance.Mapper(resturant);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error getting Resturant with id : {request.Id}" + " {@GetResturantById}", ex.Message);

                throw;
            }
        }
    }
}
