using System.Linq.Expressions;

namespace Tempo.Common.Setup.Respository
{
    /// <summary>
    /// code reuse in entity repository classes, avoid repeating code
    /// This is class generic
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="Key"></typeparam>
    public interface IBaseRepository<TEntity, Key>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? where = null, params string[] includes);
        Task<TEntity?> GetByIdAsync(Key id);
        Task<TEntity> AddAsync(TEntity entity, params Expression<Func<TEntity, object?>>[] references);
        Task<TEntity?> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object?>>[] references);
        Task<bool> DeleteAsync(Key id);
    }
}
