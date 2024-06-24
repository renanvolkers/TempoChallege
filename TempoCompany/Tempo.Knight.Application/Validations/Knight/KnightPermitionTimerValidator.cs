using FluentValidation;

namespace Tempo.Knight.Application.Validations.Knight
{
    public class KnightPermitionTimerValidator : AbstractValidator<DateTime?>
    {
        /// <summary>
        /// Rules basic for validation Knight
        ///         // Rule define hipotectic de values.
        //The CalculateCombatTraining function contains a condition that prevents requests to calculate combat
        //training from being executed at intervals shorter than 10 seconds. This measure is
        //implemented to prevent multiple requests from being sent in a short period of time,
        //which could be used to cheat in combat training calculations.
        /// </summary>
        public KnightPermitionTimerValidator()
        {

            RuleFor(x => x)
                    
                     .Must(PermitionTimeRequest)
                     .WithMessage("The Request  cannot be change should time last Update.");

        }
        private bool PermitionTimeRequest(DateTime? date)
        {
            var permitionTimerUpdate = 10;
            var dateModifed = date.HasValue ? date.Value : DateTime.MinValue;
            var timeChangeMax = DateTime.Now - dateModifed;
            if (timeChangeMax.Seconds >= permitionTimerUpdate)
            {
                return true;
            }
            return false;
        }
    }
}
