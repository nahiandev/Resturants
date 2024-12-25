using MediatR;

namespace Restaurants.Actions.Coomands.AddResturant
{
    public class AddResturantCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
