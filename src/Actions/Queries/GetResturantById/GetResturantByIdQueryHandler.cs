using MediatR;
using Restaurants.DomainMapper;
using Restaurants.Domains.DTOs;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Actions.Queries.GetResturantById
{
    public class GetResturantByIdQueryHandler : IRequestHandler<GetResturantByIdQuery, ResturantDTO?>
    {
        private readonly IResturantRepository _repository;

        public GetResturantByIdQueryHandler(IResturantRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResturantDTO?> Handle(GetResturantByIdQuery request, CancellationToken cancellationToken)
        {
                var resturant = await _repository.GetResturantByIdAsync(request.Id);

                if (resturant is null) return await Task.FromResult<ResturantDTO?>(null);

                return DataMapper.Instance.Mapper(resturant);
        }
    }
}
