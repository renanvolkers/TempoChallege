using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using Tempo.Common.Setup.Api;
using Tempo.Common.Setup.Error;
using Tempo.Common.Setup.Repository;
using Tempo.Common.Setup.Respository;


namespace Tempo.Common.Setup.Service
{
    /// <summary>
    /// code reuse in service classes, avoid repeating code
    /// This is class generic
    /// Generic method used into Controller
    /// </summary>
    /// <typeparam name="IModel"></typeparam>
    /// <typeparam name="IResponse"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public class TempoBaseService<IModel, IResponse, TRepository> :
        ITempoBaseService<IModel, IResponse>
        where IModel : IEntity<Guid>
        where IResponse: class,new()

        where TRepository : IBaseRepository<IModel, Guid>
    {

        protected IMapper _mapper;
        protected TRepository _repository;
        protected IHttpContextAccessor _httpContextAccessor;

        public TempoBaseService(IMapper mapper, TRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual async Task<BaseResponse<IResponse>> AddAsync(BaseRequest<IRequest> model, params Expression<Func<IModel, object>>[] references)
            {
                if (model.ErrorMessage.Any())
                {
                    return new BaseResponse<IResponse>(model.ErrorMessage);
                }
                var domainEntity = _mapper.Map<IModel>(model.Data);
                var newEntity = await _repository.AddAsync(domainEntity);
                return _mapper.Map<BaseResponse<IResponse>>(newEntity);

        }

        public virtual string GetUser()
        {
            return _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "Anonymous";
        }

        public virtual async Task<BaseResponse<List<IResponse>>> GetAllAsync(Expression<Func<IModel, bool>>? where = null, params string[] includes)
        {
            var result = await _repository.GetAllAsync(where);
            var viewModelResults = _mapper.Map<BaseResponse<List<IResponse>>>(result);
            return viewModelResults;
        }

        public virtual async Task<BaseResponse<IResponse>> DeleteAsync(Guid id)
        {
            IModel? result = await _repository.GetByIdAsync(id);
            await this._repository.DeleteAsync(id);
            return _mapper.Map<BaseResponse<IResponse>>(result);
        }

        public virtual async Task<BaseResponse<IResponse>> UpdateAsync<TRequest>(BaseRequest<TRequest> model, Expression<Func<IModel, bool>>? where = null, params Expression<Func<IModel, object>>[] references)
        {
            if (model.ErrorMessage.Any())
            {
                return new BaseResponse<IResponse>(model.ErrorMessage);
            }
            var entity = (await _repository.GetAllAsync(where)).FirstOrDefault();
            if (entity == null)
            {
                model.ErrorMessage.Add(new CustomValidationFailure("Id", ErrorMessages.NotFound));
                return new BaseResponse<IResponse>(model.ErrorMessage);
            }

            _mapper.Map(model.Data, entity);
            await this._repository.UpdateAsync(entity, where);
            return _mapper.Map<BaseResponse<IResponse>>(entity);
        }

        public virtual async Task<BaseResponse<IResponse>> GetByIdAsync(Guid id)
        {
            IModel? result = await this._repository.GetByIdAsync(id);
            return _mapper.Map<BaseResponse<IResponse>>(result);
        }

        protected BaseRequest<IRequest> ValidateRequest<T>(T model, AbstractValidator<T> validator) where T : IRequest
        {
            var validationResult = validator.Validate(model);
            var request = new BaseRequest<IRequest>(model)
            {
                ErrorMessage = validationResult.Errors.ToCustomValidationFailure()
            };

            return request;
        }


    }
}
