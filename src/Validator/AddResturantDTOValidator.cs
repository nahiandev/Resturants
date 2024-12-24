using FluentValidation;
using Restaurants.Models.DTOs;

namespace Restaurants.Validator
{
    public class AddResturantDTOValidator : AbstractValidator<AddResturantDTO>
    {
        public AddResturantDTOValidator()
        {
            RuleFor(r => r.Name).NotEmpty().MinimumLength(3).
                MaximumLength(50).WithMessage("Name must be between 3 and 50 characters.");
        }
    }
}
