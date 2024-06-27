using AutoMapper;
using Tempo.Knight.Application.Domain.Knights;
using Tempo.Knight.Domain.Model;
using Tempo.Knight.Domain.Model.Calculator;
using Tempo.Knight.Domain.Repositories;
using Tempo.Knight.Dto.Requests.Knight;
using Tempo.Knight.Dto.Responses;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using Tempo.Common.Setup.Api;
using Tempo.Common.Setup.Error;
using Tempo.Common.Setup.Service;
using Microsoft.AspNetCore.Identity;
using Tempo.Knight.Application.Validations.Knight;
using FluentValidation.Results;
using System.Linq;
using Tempo.Common.Setup.Util.Extension;

namespace Tempo.Knight.Application.Services.Knights
{
    /// <summary>
    /// KnightService is use dependency injection in construct.
    /// Provide service Knight consume for Controllers
    /// IManagerCalculator  dependency inversion principle 
    /// IFilterStrategy  Use Pattern Specification for high cohesion and low coupling
    /// 
    /// </summary>
    public class KnightService : TempoBaseService<Knight.Domain.Model.Knight, ResponseKnight, IKnightsRepository>, IKnightService
    {
        private readonly IFilterStrategy<Knight.Domain.Model.Knight> _filterStrategy;
        private readonly IManagerCalculator<Knight.Domain.Model.Knight, ResponseKnight> _managerCalculator;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IKnightAttributeRepository _knightAttributeRepository;

        public KnightService(IMapper mapper, IKnightsRepository knightsRepository, IAttributeRepository attributeRepository, IKnightAttributeRepository knightAttributeRepository, IFilterStrategy<Knight.Domain.Model.Knight> filterStrategy,
            IManagerCalculator<Knight.Domain.Model.Knight, ResponseKnight> managerCalculator) : base(mapper, knightsRepository)
        {
            _filterStrategy = filterStrategy;
            _managerCalculator = managerCalculator;
            _attributeRepository = attributeRepository;
            _knightAttributeRepository = knightAttributeRepository;
        }

        public async Task<BaseResponse<PagedResponse<ResponseKnight>>> GetFilterAsync(RequestFilterKnight requestFilter, int? page, int? pageSize)
        {
            List<Knight.Domain.Model.Knight>  result;

            string [] includes = ["Weapons", "KnightAttributes", "KnightAttributes.Attribute"];
            _filterStrategy.InputFilter(requestFilter.CharacterType);
            result = (await _repository.GetAllAsync(_filterStrategy.ToExpression(), includes));
            if(!string.IsNullOrWhiteSpace(requestFilter.Name))
            {
                result = result.Where(x => x.Name.ToUpper().Contains(requestFilter.Name.ToUpper())).ToList();
            }



            var totalCount = result.Count;
            var resultPage = result.ToPagedList(page, pageSize);
            var resulCalculator = _managerCalculator.Calculator(resultPage).ToList();

            var response = new PagedResponse<ResponseKnight>(resulCalculator, page.GetValueOrDefault(0), pageSize,totalCount);

            var viewModelResults = new BaseResponse<PagedResponse<ResponseKnight>>
            {
                Data = response,
            };
            return viewModelResults;
        }

        public virtual async Task<BaseResponse<ResponseKnight>> AddKnightAsync(BaseRequest<RequestKnight> model, params Expression<Func<IModel, object>>[] references)
        {

            if (model.ErrorMessage.Any())
            {
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }
            var requestKnight = model.Data ?? new RequestKnight();
            var attributes = await _attributeRepository.GetAllAsync(x =>true);

            if (!attributes.Any(x => x.Name.ToUpper() == requestKnight.KeyAttribute.ToUpper()))
            {
                model.ErrorMessage.Add(new CustomValidationFailure(requestKnight.KeyAttribute, ErrorMessages.NotFound));
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }

            model.Data?.Attributes.ToList().ForEach(attribute =>
           {
               if (!attributes.Select(attr => attr.Name.ToUpper()).Contains(attribute.Name.ToUpper()))
               {
                   model.ErrorMessage.Add(new CustomValidationFailure(attribute.Name, ErrorMessages.NotFound));
               }

           });
            if (model.ErrorMessage.Any())
            {
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }

            var domainEntity = _mapper.Map<Knight.Domain.Model.Knight>(model.Data);
            var newEntity = await _repository.AddAsync(domainEntity);
            var addAttribs = attributes.Where(x => requestKnight.Attributes.Select(x => x.Name).Contains(x.Name)).Select(x=>x.Id).ToList();
            await _knightAttributeRepository.AddAsync(domainEntity.Id, addAttribs, model.Use);
            return _mapper.Map<BaseResponse<ResponseKnight>>(newEntity);

        }

        public virtual async Task<BaseResponse<ResponseKnight>> CombatTrainingKnightAsync(BaseRequest<RequestTrainingKnight> model, Guid id, params Expression<Func<IModel, object>>[] references)
        {

            if (model.ErrorMessage.Any())
            {
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }
            var entity = (await _repository.GetByIdAsync(id));
            if (entity == null)
            {
                model.ErrorMessage.Add(new CustomValidationFailure("Id", ErrorMessages.NotFound));
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }
            var validaPermition = new KnightPermitionTimerValidator().Validate(entity.ModifiedAt);

            if (!validaPermition.IsValid)
            {
                return new BaseResponse<ResponseKnight>(validaPermition.Errors.ToCustomValidationFailure()); 

            }
            entity = (Knight.Domain.Model.Knight)_managerCalculator.CalculatorCombatTraining(entity);
            await this._repository.UpdateAsync(entity, x => x.Id == id);
            return _mapper.Map<BaseResponse<ResponseKnight>>(entity);

        }
    }
}
