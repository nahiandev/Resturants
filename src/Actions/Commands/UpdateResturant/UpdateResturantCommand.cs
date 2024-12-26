using MediatR;

namespace Restaurants.Actions.Commands.UpdateResturant
{
    public class UpdateResturantCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
