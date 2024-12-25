using FluentValidation;
using FluentValidation.Validators;
using Restaurants.DataAccessor;

namespace Restaurants.Actions.Coomands.AddResturant
{
    public class AddResturantCommandValidator : AbstractValidator<AddResturantCommand>
    {
        private readonly ResturantDbContext _context;

        public AddResturantCommandValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(r => r.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(r => r.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(r => r.Category)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(r => r.HasDelivery)
                .NotNull()
                .Must(value => value == true || value == false)
                .WithMessage("Must be a boolean value.");

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .Must(e => !_context.Resturants.Any(r => r.Email == e))
                .WithMessage("Email address must be unique.");
        }
    }
}
