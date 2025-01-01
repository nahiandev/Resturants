using MediatR;

namespace Resturants.Actions.Commands.AddDish
{
    public class AddDishCommandHandler : IRequestHandler<AddDishCommand>
    {
        private readonly ILogger<AddDishCommandHandler> _logger;

        public AddDishCommandHandler(ILogger<AddDishCommandHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(AddDishCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding new dish {@DishRequest}", request);
            throw new NotImplementedException();
        }
    }
}
