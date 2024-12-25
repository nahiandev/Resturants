using FluentValidation;
using FluentValidation.Validators;
using Restaurants.DataAccessor;
using Restaurants.Models.DTOs;

public class AddResturantDTOValidator : AbstractValidator<AddResturantDTO>
{
    private readonly ResturantDbContext _context;

    public AddResturantDTOValidator(ResturantDbContext context)
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
