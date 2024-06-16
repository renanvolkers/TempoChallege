using Tempo.Knight.Application.Validations.Weapon;
using Tempo.Knight.Dto.Requests.Knight;
using FluentValidation;

namespace Tempo.Knight.Application.Validations.Knight
{
    /// <summary>
    /// Rules basic for validation Knight
    /// </summary>
    public class AddKnightValidator : AbstractValidator<RequestKnight>
    {
        public AddKnightValidator()
        {
            RuleFor(x => x.Weapons)
                .NotNull().SetValidator(new RequestWeaponValidator());
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .MaximumLength(50).WithMessage("Name must be less than or equal to 50 characters");

            RuleFor(x => x.Nickname)
                .MaximumLength(50).WithMessage("Nick name must be less than or equal to 50 characters")
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.KeyAttribute)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Birthday)
                     .NotNull()
                     .Must(BeAValidDate)
                     .WithMessage("The anniversary date cannot be in the future.");
            RuleFor(x => x.Attributes)
                .NotNull()
                .NotEmpty();

            RuleFor(y => y.Attributes)
                .Must((x, y) => y.Where(o => o.Key == x.KeyAttribute).Any())
                .WithMessage($"Must have at least {nameof(RequestKnight.KeyAttribute)}  in {nameof(RequestKnight.Attributes)}");

        }

        private bool BeAValidDate(DateTime date)
        {
            return  date <= DateTime.Today;
        }

    }
}
