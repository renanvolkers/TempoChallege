using Tempo.Knight.Dto.Requests.Weapon;
using FluentValidation;

namespace Tempo.Knight.Application.Validations.Weapon
{
    /// <summary>
    /// Rules basic for validation Weapon
    /// </summary>
    public class RequestWeaponValidator : AbstractValidator<List<RequestWeapon>>
    {
        public RequestWeaponValidator()
        {

            RuleForEach(x => x)
                .NotNull().SetValidator( new WeaponValidator());
            RuleFor(x => x.Where(x=>x.Equipped)
                        .Count())
                .GreaterThan(0)
                .WithMessage("The knight must have at least one weapon");

            RuleFor(x => x.Where(x => x.Equipped)
            .Count())
                .LessThan(30)
                .WithMessage("The knight must have a Maximum of 30 weapons");
        }

    }
}
