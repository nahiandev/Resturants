using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Commands.UpdateResturant
{
    public class UpdateResturantCommandHandler : IRequestHandler<UpdateResturantCommand, bool>
    {
        private readonly IResturantRepository _repository;

        public UpdateResturantCommandHandler(IResturantRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
                var id = request.Id;

                var domain_resturant = DataMapper.Instance.Map(request);

                var is_updated = await _repository.UpdateResturantAsync(id, domain_resturant);

                return is_updated;
        }
    }
}
