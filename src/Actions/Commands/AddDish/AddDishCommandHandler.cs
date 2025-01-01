using MediatR;
using Restaurants.Domains.Models;
using Resturants.Repository.Interfaces;

namespace Resturants.Actions.Commands.AddDish
{
    public class AddDishCommandHandler : IRequestHandler<AddDishCommand>
    {
        private readonly IDishesRepository _repository;

        private readonly ILogger<AddDishCommandHandler> _logger;

        public AddDishCommandHandler(IDishesRepository repository, ILogger<AddDishCommandHandler> logger)
        {
            _repository = repository;

            _logger = logger;
        }
        public async Task Handle(AddDishCommand request, CancellationToken cancellation_token)
        {
            _logger.LogInformation("Adding new dish {@DishRequest}", request);

            Dish domain_dish = new()
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description
            };

            await _repository.AddDishAsync(domain_dish, cancellation_token);

            throw new NotImplementedException();
        }
    }
}
