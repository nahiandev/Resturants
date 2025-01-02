using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Domains.Models;
using Restaurants.Repository.Interfaces;
using Resturants.Repository.Interfaces;

namespace Resturants.Actions.Commands.AddDish
{
    public class AddDishCommandHandler : IRequestHandler<AddDishCommand>
    {
        private readonly IDishesRepository _dish_repository;
        private readonly IResturantRepository _resturant_repository;
        private readonly ILogger<AddDishCommandHandler> _logger;

        public AddDishCommandHandler(IDishesRepository dish_repository, 
            IResturantRepository resturant_repository,
            ILogger<AddDishCommandHandler> logger)
        {
            _dish_repository = dish_repository;
            _resturant_repository = resturant_repository;
            _logger = logger;
        }
        public async Task Handle(AddDishCommand request, CancellationToken cancellation_token)
        {
            _logger.LogInformation("Adding new dish {@DishRequest}", request);

            //var id = request.RestaurantId;

            //var resturant = await _resturant_repository.GetResturantByIdAsync(id) ?? throw new Exception(nameof(Resturant));

           
        }
    }
}
