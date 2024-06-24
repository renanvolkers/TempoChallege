

using System.Linq.Expressions;
using Tempo.Common.Setup.Respository;
using Tempo.Knight.Domain.Model;

namespace Tempo.Knight.Domain.Repositories
{
    /// <summary>
    /// methods that a class must implement
    /// objective to centralize data access logic and provide an abstraction for the data layer
    /// </summary>
    public interface IKnightAttributeRepository : IBaseRepository<KnightAttribute, Guid>
    {
        Task<List<KnightAttribute>> AddAsync(Guid knight,List<Guid> attributeIds,string use, params Expression<Func<KnightAttribute, object?>>[] references);
    }
}