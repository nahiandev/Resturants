using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Coomands.AddResturant
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
            var domain_resturant = DataMapper.Instance.Mapper(request);
            try
            {
                var saved_resturant = await _repository.AddResturantAsync(domain_resturant!);
                return saved_resturant.Id;
            }
            catch(Exception e)
            {
                return -1;
            }
        }
    }
}
