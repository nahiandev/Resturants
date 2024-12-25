using FluentValidation;
using Restaurants.Models.DTOs;

namespace Restaurants.Validator
{
    public class AddResturantDTOValidator : AbstractValidator<AddResturantDTO>
    {
        public AddResturantDTOValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().MinimumLength(3).
                MaximumLength(50);

            RuleFor(r => r.Description)
                .NotEmpty().MaximumLength(300);

            RuleFor(r => r.Category)
                .NotEmpty().MaximumLength(10);

            RuleFor(r => r.HasDelivery).NotNull()
                .Must(value => value == true || value == false)
                .WithMessage("Must be a boolean value.");

            RuleFor(r => r.Email).NotEmpty()
                .EmailAddress();
        }
    }
}
