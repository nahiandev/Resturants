﻿using FluentValidation;
using FluentValidation.Validators;
using Restaurants.Actions.Commands.UpdateResturant;
using Restaurants.DataAccessor;

namespace Restaurants.Actions.Commands.AddResturant
{
    public class UpdateResturantCommandValidator : AbstractValidator<UpdateResturantCommand>
    {
        private readonly ResturantDbContext _context;

        public UpdateResturantCommandValidator(ResturantDbContext context)
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
                .Must(BeUniqueEmail)
                .WithMessage("Email address must be unique.");
        }

        private bool BeUniqueEmail(UpdateResturantCommand command, string email)
        {
            var existing = _context.Resturants.FirstOrDefault(r => r.Id == command.Id);

            if (existing != null && existing.Email == email) return true;

            var email_exists = _context.Resturants.Any(r => r.Email == email && r.Id != command.Id);

            return !email_exists;
        }
    }
}
