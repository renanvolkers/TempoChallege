
using Tempo.Common.Setup.Respository;

namespace Tempo.Knight.Domain.Repositories
{
    /// <summary>
    /// methods that a class must implement
    /// objective to centralize data access logic and provide an abstraction for the data layer
    /// </summary>
    public interface IKnightsRepository : IBaseRepository<Model.Knight, Guid>
    {

    }
}