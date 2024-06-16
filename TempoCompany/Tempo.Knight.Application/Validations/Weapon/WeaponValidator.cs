using Tempo.Knight.Dto.Requests.Weapon;
using FluentValidation;

namespace Tempo.Knight.Application.Validations.Weapon
{
    public class WeaponValidator : AbstractValidator<RequestWeapon>
    {
        /// <summary>
        /// Rules basic for validation Weapon
        /// </summary>
        public WeaponValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50).WithMessage("Name must be less than or equal to 50 characters");

            RuleFor(x => x.Attr)
                .MaximumLength(50).WithMessage("Name must be less than or equal to 50 characters")
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Mod)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(0, 100).WithMessage("Mod must be between 0 and 20");
            RuleFor(x => x.Equipped)
                .NotNull()
                .NotEmpty();
            
        }

    }
}
