using Tempo.Knight.Dto.Requests.Knight;
using FluentValidation;

namespace Tempo.Knight.Application.Validations.Knight
{
    public class UpdateKnightValidator : AbstractValidator<RequestUpdateKnight>
    {
        /// <summary>
        /// Rules basic for validation Knight
        /// </summary>
        public UpdateKnightValidator()
        {
            RuleFor(x => x.Nickname)
                .MaximumLength(50).WithMessage("Name must be less than or equal to 50 characters")
                .NotNull()
                .NotEmpty();

        }

    }
}
