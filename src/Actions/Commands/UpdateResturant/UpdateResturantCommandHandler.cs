using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Commands.UpdateResturant
{
    public class UpdateResturantCommandHandler : IRequestHandler<UpdateResturantCommand, bool>
    {
        private readonly IResturantRepository _repository;

        private readonly ILogger<UpdateResturantCommandHandler> _logger;

        public UpdateResturantCommandHandler(IResturantRepository repository, ILogger<UpdateResturantCommandHandler> logger)
        {
            _repository = repository;

            _logger = logger;
        }

        public async Task<bool> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating Resturant with {@UpdateResturant}", request);

            try
            {
                var id = request.Id;

                var domain_resturant = DataMapper.Instance.Mapper(request);

                var is_updated = await _repository.UpdateResturantAsync(id, domain_resturant);

                return is_updated;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error updating Resturant with {@UpdateResturant}", ex.Message);

                throw;
            }
        }
    }
}
