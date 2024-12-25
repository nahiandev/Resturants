using MediatR;

namespace Restaurants.Actions.Commands.DeleteResturant
{
    public class DeleteResturantCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteResturantCommand(int id)
        {
            Id = id;
        }
    }
}
