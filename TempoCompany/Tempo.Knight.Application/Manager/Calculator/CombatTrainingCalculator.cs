using Tempo.Knight.Domain.Model;
using Tempo.Knight.Domain.Model.Calculator;

namespace Tempo.Knight.Application.Manager.Calculator
{
    /// <summary>
    /// calculates the Combaet training value of a Knight in the domain 
    /// of a game or character modeling system.
    /// </summary>
    /// <param name="knight"></param>
    /// </returns>
    public class CombatTrainingCalculator : ICombatTrainingCalculator
    {
        // Rule define hipotectic de values.
        //The CalculateCombatTraining function contains a condition that prevents requests to calculate combat
        //training from being executed at intervals shorter than 10 seconds. This measure is
        //implemented to prevent multiple requests from being sent in a short period of time,
        //which could be used to cheat in combat training calculations.
        public IKnight CalculateCombatTraining(Knight.Domain.Model.Knight knight)
        {
            knight.ModifiedAt = DateTime.Now;
            knight.CombatTraining = knight.CombatTraining + Math.Pow(11, 1.45) + 0.0004;
            
            return knight;
        }
    }
}
