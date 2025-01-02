using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Commands.AddResturant
{
    public class AddResturantCommandHandler : IRequestHandler<AddResturantCommand, int>
    {
        private readonly IResturantRepository _repository;

        public AddResturantCommandHandler(IResturantRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(AddResturantCommand request, CancellationToken cancellationToken)
        {
            var domain_resturant = DataMapper.Instance.Map(request);

                var saved_resturant = await _repository.AddResturantAsync(domain_resturant!);
               
                return saved_resturant.Id;
        }
    }
}
