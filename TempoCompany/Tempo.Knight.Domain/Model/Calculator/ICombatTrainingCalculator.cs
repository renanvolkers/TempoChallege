namespace Tempo.Knight.Domain.Model.Calculator
{
    public interface ICombatTrainingCalculator
    {
        IKnight CalculateCombatTraining(Knight knight);
    }
}
