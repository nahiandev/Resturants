using MediatR;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Commands.DeleteResturant
{
    public class DeleteResturantCommandHandler : IRequestHandler<DeleteResturantCommand, bool>
    {
        private readonly IResturantRepository _repository;

        public DeleteResturantCommandHandler(IResturantRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
                var is_deleted = await _repository.DeleteResturantAsync(request.Id);

                return is_deleted;
        }
    }
}
