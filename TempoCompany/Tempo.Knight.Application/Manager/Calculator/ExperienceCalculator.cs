using Tempo.Knight.Domain.Model.Calculator;

namespace Tempo.Knight.Application.Manager.Calculator
{
    /// <summary>
    /// calculates the Experience value of a Knight in the domain 
    /// of a game or character modeling system.
    /// </summary>
    /// <param name="knight"></param>
    /// </returns>
    public class ExperienceCalculator : IExperienceCalculator
    {
        // Rule define hipotectic de values.
        public int CalculateExperience(Knight.Domain.Model.Knight  knight)
        {
            var age = (DateTime.Today.Year - knight.Birthday.Year);
            if (age < 7)
                return 0;

            return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45)) + (int)Math.Round(knight.CombatTraining, 2);
        }
    }
}
