
using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model.Calculator
{
    /// <summary>
    /// Violation of SOLID in the DE principle: Dependency inversion was applied to the experiment and attack calculations.
    /// Class GENERIC 
    /// If a new type of calculation appears, add the new class to this list.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public interface IManagerCalculator<TEntity,TDto> where TEntity : IEntity<Guid>
                                                      where TDto : class
    {
        IEnumerable<TDto> Calculator(IEnumerable<TEntity> knights);
    }
}
