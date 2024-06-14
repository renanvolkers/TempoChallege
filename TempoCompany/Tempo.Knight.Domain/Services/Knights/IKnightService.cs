using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using Tempo.Common.Setup.Api;
using Tempo.Common.Setup.Service;
using Tempo.Knight.Dto.Requests.Knight;
using Tempo.Knight.Dto.Responses;

namespace Tempo.Knight.Application.Domain.Knights
{
    public interface IKnightService : ITempoBaseService<Knight.Domain.Model.Knight,ResponseKnight>
    {
        Task<BaseResponse<List<ResponseKnight>>> GetFilterAsync(string Filter = "");
        Task<BaseResponse<ResponseKnight>> AddKnightAsync(BaseRequest<RequestKnight> request, params Expression<Func<IModel, object>>[] references);

    }
}
