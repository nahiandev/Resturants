using MediatR;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Commands.DeleteResturant
{
    public class DeleteResturantCommandHandler : IRequestHandler<DeleteResturantCommand, bool>
    {
        private readonly IResturantRepository _repository;

        private readonly ILogger<DeleteResturantCommandHandler> _logger;

        public DeleteResturantCommandHandler(IResturantRepository repository, ILogger<DeleteResturantCommandHandler> logger)
        {
            _repository = repository;

            _logger = logger;
        }

        public async Task<bool> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting Resturant with {@DeleteResturant}", request);

            try
            {
                var is_deleted = await _repository.DeleteResturantAsync(request.Id);

                return is_deleted;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error deleting Resturant with id : {request.Id}" + " {@DeleteResturant}", ex.Message);

                throw;
            }
        }
    }
}
