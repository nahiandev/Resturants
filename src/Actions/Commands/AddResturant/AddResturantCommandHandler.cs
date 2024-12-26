using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Commands.AddResturant
{
    public class AddResturantCommandHandler : IRequestHandler<AddResturantCommand, int>
    {
        private readonly IResturantRepository _repository;

        private readonly ILogger<AddResturantCommandHandler> _logger;

        public AddResturantCommandHandler(IResturantRepository repository, ILogger<AddResturantCommandHandler> logger)
        {
            _repository = repository;

            _logger = logger;
        }
        public async Task<int> Handle(AddResturantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding a new Resturant with {@AddResturant}", request);

            var domain_resturant = DataMapper.Instance.Mapper(request.Properties);

            try
            {
                var saved_resturant = await _repository.AddResturantAsync(domain_resturant!);

                return saved_resturant.Id;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error adding Resturants with {@AddResturant}", ex.Message);

                throw;
            }
        }
    }
}
