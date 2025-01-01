using FluentValidation;

namespace Resturants.Actions.Commands.AddDish
{
    public class AddDishCommandValidator : AbstractValidator<AddDishCommand>
    {
        public AddDishCommandValidator()
        {
            RuleFor(dish => dish.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(dish => dish.KiloCalories)
                .GreaterThan(0)
                .WithMessage("KiloCalories must be greater than 0");
        }
    }
}
