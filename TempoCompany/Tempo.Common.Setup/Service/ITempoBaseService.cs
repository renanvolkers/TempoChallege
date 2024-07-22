
using System.Linq.Expressions;
using Tempo.Common.Setup.Api;
using Tempo.Common.Setup.Repository;

namespace Tempo.Common.Setup.Service
{

    /// <summary>
    /// Interface/Contracts
    ///  code reuse in service classes, avoid repeating code
    /// This is class generic
    /// </summary>
    /// <typeparam name="IModel"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface ITempoBaseService<IModel, TResponse>
        where IModel : IEntity<Guid>
        where TResponse : class, new()
    {
        Task<BaseResponse<List<TResponse>>> GetAllAsync(Expression<Func<IModel, bool>>? where = null, params string[] includes);
        Task<BaseResponse<TResponse>> GetByIdAsync(Guid id);
        Task<BaseResponse<TResponse>> AddAsync(BaseRequest<IRequest> request, params Expression<Func<IModel, object>>[] references);
        Task<BaseResponse<TResponse>> UpdateAsync<TRequest>(BaseRequest<TRequest> request, Expression<Func<IModel, bool>>? where = null, params Expression<Func<IModel, object>>[] references);
        Task<BaseResponse<TResponse>> DeleteAsync(Guid id);
        string GetUser();
    }
}
